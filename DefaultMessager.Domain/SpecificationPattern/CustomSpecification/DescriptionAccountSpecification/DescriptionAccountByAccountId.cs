using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification
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
