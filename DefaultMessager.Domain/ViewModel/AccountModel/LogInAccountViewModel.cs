using DefaultMessager.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class LogInAccountViewModel
    {

        [Required(ErrorMessage = "input login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "input password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LogInAccountViewModel(Account account)
        {
            Login = account.Login;
            Password = account.Password;
        }

        public LogInAccountViewModel()
        {
        }
    }
}
