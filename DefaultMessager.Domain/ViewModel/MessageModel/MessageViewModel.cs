using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.ViewModel.MessageModel
{
    public class MessageViewModel
    {
        public Guid? Id { get; set; }
        public Guid RecieveId { get; set; }
        public Guid SenderId { get; set; }
        public string[]? PathPictures { get; set; }
        public string[]? PathAudios { get; set; }
        public DateTime SendDateTime { get; set; }
        public StatusMessage MessageStatus { get; set; }
        public string? MessageTextContent { get; set; }
    }
}
