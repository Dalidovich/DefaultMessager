using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Domain.ViewModel.PostModel
{
    public class PostViewModel
    {
        public Guid? Id { get; set; }
        public string[]? PathPictures { get; set; }
        public string? PostTextContent { get; set; }
        public string? Title { get; set; }
        public string[]? PathAudios { get; set; }
        public DateTime SendDateTime { get; set; }
        public AccountIconViewModel? Account { get; set; }
    }
}
