namespace DefaultMessager.Domain.Entities
{
    public class Like
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid AccountId { get; set; }
        public Account? User { get; set; }
        public Post? Post { get; set; }
        public Like(Guid postId, Guid accountId)
        {
            PostId = postId;
            AccountId = accountId;
        }
        public Like()
        {
        }
    }
}
