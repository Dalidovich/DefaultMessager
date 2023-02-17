using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
{
    public class AccountById<T> : Specification<Account>
    {
        private readonly Guid _accountId;
        public AccountById(Guid id)
        {
            _accountId = id;
            expression = x => x.Id == _accountId;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
