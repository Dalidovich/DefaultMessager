using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.CommentSpecification
{
    public class CommentById<T> : Specification<Comment>
    {
        private readonly Guid _commentId;
        public CommentById(Guid id)
        {
            _commentId = id;
            expression = x => x.Id == _commentId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
