namespace DefaultMessager.BLL.Hubs
{
    public interface ICommunicationHub
    {
        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMessageAsync(string userName, string message);
        Task RemoveConnectionInGroup(string connectionId, string groupId);
        Task SendMessageInGroupAsync(string userName, string message, string groupId);

        /// <summary>W
        /// Update user list
        /// </summary>
        /// <param name="users"></param>
        Task UpdateUsersAsync(IEnumerable<string> users);
        Task SetConnectionInGroup(string connectionId, string groupId);
    }
}
