using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountIconViewModel
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }=null!;
        public DescriptionPathAvatarAccountViewModel PathAvatar;
        public AccountIconViewModel(Guid? id, string login)
        {
            Id = id;
            Login = login;
        }

        public AccountIconViewModel(Account account)
        {
            Id = account.Id;
            Login = account.Login;
        }
    }
}
