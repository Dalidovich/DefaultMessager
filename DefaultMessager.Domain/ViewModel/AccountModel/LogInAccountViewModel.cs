using System.ComponentModel.DataAnnotations;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class LogInAccountViewModel
    {
        [Required(ErrorMessage = "input login")]
        public string login { get; set; }

        [Required(ErrorMessage = "input password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
