using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.AccountModel
{
    public class AccountIconView
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }=null!;
        public AccountIconView(Guid? id, string login)
        {
            Id = id;
            Login = login;
        }

        public AccountIconView(Account account)
        {
            Id = account.Id;
            Login = account.Login;
        }
    }
}
