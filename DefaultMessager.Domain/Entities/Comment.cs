namespace DefaultMessager.Domain.Entities
{
    public class Comment
    {
        public long? CommentId { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string? CommentTextContent { get; set; }
        public DateTime DatePublicate { get; set; }
        public short CommentStatus { get; set; }
        public Post? Post { get; set; }  
        public User? User { get; set; }
        public Comment(long postId, long userId, string commentText, DateTime datePublicate, short status)
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
