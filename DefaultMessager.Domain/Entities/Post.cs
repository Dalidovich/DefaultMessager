namespace DefaultMessager.Domain.Entities
{
    public class Post
    {
        public long? PostId { get; set; }
        public long UserId { get; set; }
        public string[]? PathPictures { get; set; } 
        public string? PostTextContent { get; set; } 
        public string? Title { get; set; }
        public string[]? PathAudios { get; set; } 
        public DateTime SendDateTime { get; set; }
        public User? User { get; set; }
        public Post(long userId)
        {
            UserId = userId;
        }

        public Post(long userId, string[] pathPictures, string text, string title, string[] pathAudios, DateTime sendDateTime)
        {
            UserId = userId;
            PathPictures = pathPictures;
            PostTextContent = text;
            Title = title;
            PathAudios = pathAudios;
            SendDateTime = sendDateTime;
        }
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
