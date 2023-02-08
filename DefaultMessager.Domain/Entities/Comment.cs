namespace DefaultMessager.Domain.Entities
{
    public class Comment
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string? CommentTextContent { get; set; }
        public DateTime DatePublicate { get; set; }
        public short CommentStatus { get; set; }
        public Post? Post { get; set; }  
        public User? User { get; set; }
        public Comment(Guid postId, Guid userId, string commentText, DateTime datePublicate, short status)
        {
            PostId = postId;
            UserId = userId;
            CommentTextContent = commentText;
            DatePublicate = datePublicate;
            CommentStatus = status;
        }
        public Comment()
        {
        }
    }
}
