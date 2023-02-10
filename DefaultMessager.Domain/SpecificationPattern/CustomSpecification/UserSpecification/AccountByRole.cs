using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
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
