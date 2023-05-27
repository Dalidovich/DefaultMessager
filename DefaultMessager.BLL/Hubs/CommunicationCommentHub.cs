using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace DefaultMessager.BLL.Hubs
{
    public class CommunicationCommentHub : Hub<ICommunicationHub>
    {
        private readonly ChatManager _chatManager;
        private string _defaultGroupName = "General";

        public CommunicationCommentHub(ChatManager chatManager)
            => _chatManager = chatManager;

        #region overrides

        /// <summary>
        /// Called when a new connection is established with the hub.
        /// </summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous connect.</returns>
        public override async Task OnConnectedAsync()
        {
            var userName = Context.User?.Identity?.Name ?? "Anonymous";
            var connectionId = Context.ConnectionId;
            _chatManager.ConnectUser(userName, connectionId);
            await UpdateUsersAsync();
            await base.OnConnectedAsync();
        }

        /// <summary>Called when a connection with the hub is terminated.</summary>
        /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous disconnect.</returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var isUserRemoved = _chatManager.DisconnectUser(Context.ConnectionId);
            if (!isUserRemoved)
            {
                await base.OnDisconnectedAsync(exception);
            }
            await UpdateUsersAsync();
            await base.OnDisconnectedAsync(exception);
        }

        #endregion

        public async Task UpdateUsersAsync()
        {
            var users = _chatManager.Users.Select(x => x.UserName).ToList();
            await Clients.All.UpdateUsersAsync(users);
        }

        public async Task SendMessageAsync(string userName, string message) =>
            await Clients.All.SendMessageAsync(userName, message);

        public async Task SendMessageInGroupAsync(string userName, string message, string groupId)
        {
            await Clients.OthersInGroup(groupId).SendMessageInGroupAsync(userName, message, groupId);
        }
        public async Task SetConnectionInGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }
        public async Task RemoveConnectionInGroup(string groupId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }
    }
}
