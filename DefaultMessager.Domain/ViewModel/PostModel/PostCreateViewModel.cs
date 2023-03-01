using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DefaultMessager.Domain.ViewModel.PostModel
{
    public class PostCreateViewModel
    {
        [Required(ErrorMessage = "input email")]
        [MaxLength(200, ErrorMessage = "max length - 200")]
        [MinLength(1, ErrorMessage = "min length - 1")]
        public string PostTextContent { get; set; }
        [MaxLength(20, ErrorMessage = "max length - 20")]
        [MinLength(1, ErrorMessage = "min length - 1")]
        public string Title { get; set; }

        public IFormFileCollection FormFiles { get; set; }
    }
}
