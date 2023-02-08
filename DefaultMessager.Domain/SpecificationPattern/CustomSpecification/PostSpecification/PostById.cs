using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification
{
    public class PostById<T> : Specification<Post>
    {
        private readonly int _postId;
        public PostById(int id)
        {
            _postId = id;
            expression = post => post.PostId == _postId;
        }
        public override Expression<Func<Post, bool>> ToExpression()
        {
            return expression;
        }
    }
}
