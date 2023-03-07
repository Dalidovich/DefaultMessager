using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountProfileByLogin<T> : Specification<AccountProfileViewModel>
    {
        private readonly string _login;
        public AccountProfileByLogin(string login)
        {
            _login = login;
            expression = x => x.Login == _login;
        }
        public override Expression<Func<AccountProfileViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
