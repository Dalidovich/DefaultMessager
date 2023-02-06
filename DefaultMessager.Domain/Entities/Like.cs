namespace DefaultMessager.Domain.Entities
{
    public class Like
    {
        public long? LikeId { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
        public Like()
        {
        }

        public Like(long postId, long userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
}
