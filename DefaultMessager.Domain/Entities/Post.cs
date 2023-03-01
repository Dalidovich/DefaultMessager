using DefaultMessager.Domain.ViewModel.PostModel;

namespace DefaultMessager.Domain.Entities
{
    public class Post
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string[]? PathPictures { get; set; }
        public string? PostTextContent { get; set; }
        public string? Title { get; set; }
        public string[]? PathAudios { get; set; }
        public DateTime SendDateTime { get; set; }
        public Account? Account { get; set; }
        public Post(Guid accountId, string[] pathPictures, string text, string title, string[] pathAudios, DateTime sendDateTime)
        {
            AccountId = accountId;
            PathPictures = pathPictures;
            PostTextContent = text;
            Title = title;
            PathAudios = pathAudios;
            SendDateTime = sendDateTime;
        }
        public Post(Guid accountId)
        {
            AccountId = accountId;
        }

        public Post()
        {
        }

        public Post(PostCreateViewModel postCreateViewModel,Guid accountId)
        {
            AccountId = accountId;
            PostTextContent= postCreateViewModel.PostTextContent;
            Title = postCreateViewModel.Title;
            SendDateTime=DateTime.Now;
        }

        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
