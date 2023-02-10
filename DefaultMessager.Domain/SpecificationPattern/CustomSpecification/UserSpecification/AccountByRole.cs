using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
{
    public class AccountByRole<T> : Specification<Account>
    {
        private readonly short _role;
        public AccountByRole(short role)
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
