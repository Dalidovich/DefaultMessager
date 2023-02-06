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
        public ImageAlbum(string[] image, long userId)
        {
            PathPictures = image;
            UserId = userId;
        }
    }
}
