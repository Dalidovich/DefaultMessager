using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.LikeSpecification
{
    public class LikeByPostId<T> : Specification<Like>
    {
        private readonly Guid _postId;
        public LikeByPostId(Guid id)
        {
            _postId = id;
            expression = x => x.PostId == _postId;
        }
        public override Expression<Func<Like, bool>> ToExpression()
        {
            return expression;
        }
    }
}
