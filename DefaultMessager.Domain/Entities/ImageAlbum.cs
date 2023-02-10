namespace DefaultMessager.Domain.Entities
{
    public class ImageAlbum
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string[] PathPictures { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Account? User { get; set; }
        public ImageAlbum(Guid accountId, string[] pathPictures, string title) : this(accountId)
        {
            PathPictures = pathPictures;
            Title = title;
        }
        public ImageAlbum(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
