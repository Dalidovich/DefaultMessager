using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.LikeSpecification
{
    public class LikeById<T> : Specification<Like>
    {
        private readonly Guid _likeId;
        public LikeById(Guid id)
        {
            _likeId = id;
            expression = x => x.Id == _likeId;
        }
        public override Expression<Func<Like, bool>> ToExpression()
        {
            return expression;
        }
    }
}
