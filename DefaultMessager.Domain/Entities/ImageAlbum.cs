namespace DefaultMessager.Domain.Entities
{
    public class ImageAlbum
    {
        public long? ImageAlbumId { get; set; }
        public long UserId { get; set; }
        public string[] PathPictures { get; set; } = null!;
        public string Title { get; set; } = null!;
        public User? User { get; set; }
        public ImageAlbum(long userId)
        {
            UserId = userId;
        }

        public ImageAlbum(long userId, string[] pathPictures, string title) : this(userId)
        {
            PathPictures = pathPictures;
            Title = title;
        }
    }
}
