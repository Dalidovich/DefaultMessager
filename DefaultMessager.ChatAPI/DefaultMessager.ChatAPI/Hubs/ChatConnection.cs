using System.Text.RegularExpressions;

namespace DefaultMessager.ChatAPI.Hubs
{
    public class ChatConnection
    {
        /// <summary>
        /// Registered at time
        /// </summary>
        public DateTime ConnectedAt { get; set; }

        /// <summary>
        /// Connection Id from client
        /// </summary>
        public string ConnectionId { get; set; } = null!;
    }
}
