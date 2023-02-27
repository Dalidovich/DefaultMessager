using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountIconViewModel
    {
        public Guid? Id { get; set; }
        public string Login { get; set; } = null!;
        public DescriptionPathAvatarAccountViewModel PathAvatar { get; set; }
        public AccountIconViewModel(Guid? id, string login)
        {
            Id = id;
            Login = login;
        }
        public AccountIconViewModel(Account account)
        {
            Id = account.Id;
            Login = account.Login;
            PathAvatar = new DescriptionPathAvatarAccountViewModel(account.Description.PathAvatar);
        }

        public AccountIconViewModel()
        {
        }
    }
}
