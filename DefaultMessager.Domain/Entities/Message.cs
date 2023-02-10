using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.Entities
{
    public class Message
    {
        public Guid? Id { get; set; }
        public Guid RecieveId { get; set; }
        public Guid SenderId { get; set; }
        public string[]? PathPictures { get; set; } 
        public string[]? PathAudios { get; set; } 
        public DateTime SendDateTime { get; set; }
        public StatusMessage MessageStatus { get; set; }
        public string? MessageTextContent { get; set; }
        public Account? Sender { get; set; }
        public Account? Reciever { get; set; }
        public Message(Guid recieveId, Guid senderId, string[] pictures, string[] audios, DateTime sendDateTime, StatusMessage messageStatus, string text)
        {
            RecieveId = recieveId;
            SenderId = senderId;
            PathPictures = pictures;
            PathAudios = audios;
            SendDateTime = sendDateTime;
            MessageStatus = messageStatus;
            MessageTextContent = text;
        }
        public Message() { }
    }
}
