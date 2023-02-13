using DefaultMessager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class RegisterAccountViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "input email")]
        [MaxLength(20, ErrorMessage = "max length - 20")]
        [MinLength(3, ErrorMessage = "min length - 3")]
        public string Email { get; set; }

        [Required(ErrorMessage = "input login")]
        [MaxLength(20, ErrorMessage = "max length - 20")]
        [MinLength(3, ErrorMessage = "min length - 3")]
        public string Login { get; set; }

        [Required(ErrorMessage = "input password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "min length - 6")]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "passwords not compare")]
        public string passwordConfirm { get; set; }
    }
}
