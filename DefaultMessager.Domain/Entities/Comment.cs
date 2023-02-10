namespace DefaultMessager.Domain.Entities
{
    public class Comment
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid AccountId { get; set; }
        public string? CommentTextContent { get; set; }
        public DateTime DatePublicate { get; set; }
        public short CommentStatus { get; set; }
        public Post? Post { get; set; }  
        public Account? User { get; set; }
        public Comment(Guid postId, Guid accountId, string commentText, DateTime datePublicate, short status)
        {
            PostId = postId;
            AccountId = accountId;
            CommentTextContent = commentText;
            DatePublicate = datePublicate;
            CommentStatus = status;
        }
        public Comment()
        {
        }
    }
}
