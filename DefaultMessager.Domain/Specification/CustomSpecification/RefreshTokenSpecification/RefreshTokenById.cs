using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RefreshTokenSpecification
{
    public class RefreshTokenById<T> : Specification<RefreshToken>
    {
        private readonly Guid _refreshTokenId;
        public RefreshTokenById(Guid id)
        {
            _refreshTokenId = id;
            expression = x => x.Id == _refreshTokenId;
        }
        public override Expression<Func<RefreshToken, bool>> ToExpression()
        {
            return expression;
        }
    }
}
