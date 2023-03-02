using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.ViewModel.CommentModel
{
    public class CommentViewModel
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string? CommentTextContent { get; set; }
        public DateTime DatePublicate { get; set; }
        public StatusComment CommentStatus { get; set; }
        public Account? Account { get; set; }
    }
}
