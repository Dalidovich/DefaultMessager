using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountByRole<T> : Specification<Account>
    {
        private readonly Role _role;
        public AccountByRole(Role role)
        {
            _role = role;
            expression = x => x.Role == _role;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
