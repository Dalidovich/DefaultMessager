using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.LikeSpecification
{
    public class LikeByAccountId<T> : Specification<Like>
    {
        private readonly Guid _accountId;
        public LikeByAccountId(Guid id)
        {
            _accountId = id;
            expression = x => x.AccountId == _accountId;
        }
        public override Expression<Func<Like, bool>> ToExpression()
        {
            return expression;
        }
    }
}
