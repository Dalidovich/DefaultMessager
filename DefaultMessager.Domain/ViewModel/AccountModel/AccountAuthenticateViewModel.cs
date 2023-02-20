using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountAuthenticateViewModel
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DescriptionAccount? Description { get; set; }
        public RefreshToken? RefreshToken { get; set; }
        public Role Role { get; set; }
        public AccountAuthenticateViewModel(Account account)
        {
            Id = account.Id;
            Login = account.Login;
            Password = account.Password;
            Salt = account.Salt;
            RefreshToken = account.RefreshToken;
            Description = account.Description;
            Role = account.Role;
        }

        public AccountAuthenticateViewModel()
        {
        }
    }
}
