namespace DefaultMessager.Domain.Entities
{
    public class Message
    {
        public long? MessageId { get; set; }
        public long RecieveId { get; set; }
        public long SenderId { get; set; }
        public string[]? PathPictures { get; set; } 
        public string[]? PathAudios { get; set; } 
        public DateTime SendDateTime { get; set; }
        public short MessageStatus { get; set; }
        public string? MessageTextContent { get; set; }
        public User? Sender { get; set; }
        public User? Reciever { get; set; }
        public Message() { }
        public Message(long recieveId, long senderId, string[] pictures, string[] audios, DateTime sendDateTime, short messageStatus, string text)
        {
            RecieveId = recieveId;
            SenderId = senderId;
            PathPictures = pictures;
            PathAudios = audios;
            SendDateTime = sendDateTime;
            MessageStatus = messageStatus;
            MessageTextContent = text;
        }
    }
}
