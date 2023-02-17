using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Domain.ViewModel.RelationModel;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountProfileViewModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime CreateDate { get; set; }
        public DescriptionAccountViewModel? Description { get; set; }
        const int firstLoadPostCount = 36;
        public List<PostIconViewModel> Posts { get; set; } = new List<PostIconViewModel>();
        public List<Guid> PostsId { get; set; } = new List<Guid>();
        public List<RelationViewModel> RelationsFrom { get; set; } = new List<RelationViewModel>();
    }
}
