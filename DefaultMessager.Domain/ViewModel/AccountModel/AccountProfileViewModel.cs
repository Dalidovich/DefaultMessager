using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountProfileViewModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public DateTime CreateDate { get; set; }
        public DescriptionAccountViewModel? Description { get; set; }
        const int firstLoadPostCount = 36;
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Guid> PostsId { get; set; } = new List<Guid>();
        public List<Relations> RelationsFrom { get; set; } = new List<Relations>();
    }
}
