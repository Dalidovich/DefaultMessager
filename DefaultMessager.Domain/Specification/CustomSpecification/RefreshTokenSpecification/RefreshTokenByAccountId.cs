using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RefreshTokenSpecification
{
    public class RefreshTokenByAccountId<T> : Specification<RefreshToken>
    {
        private readonly Guid _accountId;
        public RefreshTokenByAccountId(Guid id)
        {
            _accountId = id;
            expression = x => x.AccountId == _accountId;
        }
        public override Expression<Func<RefreshToken, bool>> ToExpression()
        {
            return expression;
        }
    }
}
