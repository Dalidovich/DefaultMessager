using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.DescriptionAccountModel
{
    public class DescriptionAccountViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Describe { get; set; }
        public string? AccountStatus { get; set; }
        public string? PathAvatar { get; set; }
    }
}
