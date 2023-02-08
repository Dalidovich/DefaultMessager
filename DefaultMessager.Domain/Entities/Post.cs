namespace DefaultMessager.Domain.Entities
{
    public class Post
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string[]? PathPictures { get; set; } 
        public string? PostTextContent { get; set; } 
        public string? Title { get; set; }
        public string[]? PathAudios { get; set; } 
        public DateTime SendDateTime { get; set; }
        public User? User { get; set; }
        public Post(Guid userId, string[] pathPictures, string text, string title, string[] pathAudios, DateTime sendDateTime)
        {
            UserId = userId;
            PathPictures = pathPictures;
            PostTextContent = text;
            Title = title;
            PathAudios = pathAudios;
            SendDateTime = sendDateTime;
        }
        public Post(Guid userId)
        {
            UserId = userId;
        }
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
