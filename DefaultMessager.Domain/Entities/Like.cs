namespace DefaultMessager.Domain.Entities
{
    public class Like
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
        public Like(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }
        public Like()
        {
        }
    }
}
