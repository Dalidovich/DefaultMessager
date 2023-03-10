using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.ImageAlbumModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Domain.ViewModel.RelationModel;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountProfileViewModel
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime CreateDate { get; set; }
        public DescriptionAccountViewModel? Description { get; set; }
        public List<PostIconViewModel> Posts { get; set; } = new List<PostIconViewModel>();
        public List<ImageAlbumViewModel> ImageAlbums { get; set; } = new List<ImageAlbumViewModel>();
        public List<RelationsViewModel> RelationsFrom { get; set; } = new List<RelationsViewModel>();
    }
}
