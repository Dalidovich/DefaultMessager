using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.AccountSpecification
{
    public class AccountByLogin<T> : Specification<Account>
    {
        private readonly string _login;
        public AccountByLogin(string login)
        {
            _login = login;
            expression = x => x.Login == _login;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
