using DefaultMessager.Domain.ViewModel.ImageAlbumModel;

namespace DefaultMessager.Domain.Entities
{
    public class ImageAlbum
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string[] PathPictures { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Account? Account { get; set; }

        public ImageAlbum(Guid accountId, string[] pathPictures, string title) : this(accountId)
        {
            PathPictures = pathPictures;
            Title = title;
        }

        public ImageAlbum(Guid accountId)
        {
            AccountId = accountId;
        }

        public ImageAlbum(ImageAlbumCreateViewModel viewModel, Guid accountId,string firstPhoto)
        {
            AccountId = accountId;
            Title= viewModel.Title;
            PathPictures = new string[] { firstPhoto };
        }
    }
}
