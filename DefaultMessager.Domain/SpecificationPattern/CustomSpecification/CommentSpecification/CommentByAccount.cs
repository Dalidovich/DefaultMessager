using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification
{
    public class CommentByAccount<T> : Specification<Comment>
    {
        private readonly Guid _commentId;
        public CommentByAccount(Guid id)
        {
            _commentId = id;
            expression = x => x.AccountId == _commentId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
