using DefaultMessager.Domain.Entities;
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

        public MessageViewModel(Message data)
        {
            Id = data.Id;
            RecieveId= data.RecieveId;
            SenderId = data.SenderId;
            PathAudios= data.PathAudios;
            PathPictures= data.PathPictures;
            SendDateTime= data.SendDateTime;
            MessageStatus = data.MessageStatus;
            MessageTextContent = data.MessageTextContent;
        }

        public MessageViewModel()
        {
        }
    }
}
