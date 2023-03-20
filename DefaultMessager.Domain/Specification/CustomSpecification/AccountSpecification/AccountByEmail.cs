using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountByEmail<T> : Specification<Account>
    {
        private readonly string _email;
        public AccountByEmail(string email)
        {
            _email = email;
            expression = x => x.Email == _email;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
