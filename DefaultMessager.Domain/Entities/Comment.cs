namespace DefaultMessager.Domain.Entities
{
    public class Comment
    {
        public long? CommentId { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string? Text { get; set; }
        public DateTime DatePublicate { get; set; }
        public DateTime DateModified { get; set; }
        public short CommentStatus { get; set; }
        public Post? Post { get; set; }  
        public User? User { get; set; }
        public Comment(long postId, long userId, string commentText, DateTime datePublicate, DateTime dateModified, short status)
        {
            PostId = postId;
            UserId = userId;
            Text = commentText;
            DatePublicate = datePublicate;
            DateModified = dateModified;
            CommentStatus = status;
        }

        public Comment()
        {
        }
    }
}
