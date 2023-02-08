namespace DefaultMessager.Domain.Entities
{
    public class ImageAlbum
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string[] PathPictures { get; set; } = null!;
        public string Title { get; set; } = null!;
        public User? User { get; set; }
        public ImageAlbum(Guid userId, string[] pathPictures, string title) : this(userId)
        {
            PathPictures = pathPictures;
            Title = title;
        }
        public ImageAlbum(Guid userId)
        {
            UserId = userId;
        }
    }
}
