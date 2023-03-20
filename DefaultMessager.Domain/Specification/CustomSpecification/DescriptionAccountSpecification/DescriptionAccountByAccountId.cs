using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.DescriptionAccountSpecification
{
    public class DescriptionAccountByAccountId<T> : Specification<DescriptionAccount>
    {
        private readonly Guid _accountId;
        public DescriptionAccountByAccountId(Guid id)
        {
            _accountId = id;
            expression = x => x.AccountId == _accountId;
        }
        public override Expression<Func<DescriptionAccount, bool>> ToExpression()
        {
            return expression;
        }
    }
}
