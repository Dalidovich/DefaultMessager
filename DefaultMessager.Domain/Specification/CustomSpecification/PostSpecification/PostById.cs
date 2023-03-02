using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification
{
    public class PostById<T> : Specification<Post>
    {
        private readonly Guid _postId;
        public PostById(Guid id)
        {
            _postId = id;
            expression = x => x.Id == _postId;
        }
        public override Expression<Func<Post, bool>> ToExpression()
        {
            return expression;
        }
    }
}
