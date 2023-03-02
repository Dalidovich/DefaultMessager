using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Domain.ViewModel.PostModel
{
    public class PostIconViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string[]? PathPictures { get; set; }
        public AccountIconViewModel? AccountViewModel { get; set; }
        public DateTime SendDateTime { get; set; }
        public PostIconViewModel(Guid? id, string? title, string[]? pathPictures)
        {
            Id = id;
            Title = title;
            PathPictures = pathPictures;
        }

        public PostIconViewModel()
        {
        }
    }
}
