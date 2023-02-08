using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification
{
    public class CommentById<T> : Specification<Comment>
    {
        private readonly int _commentId;
        public CommentById(int id)
        {
            _commentId = id;
            expression = post => post.CommentId == _commentId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
