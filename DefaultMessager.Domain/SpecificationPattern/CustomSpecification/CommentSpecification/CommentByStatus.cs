using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification
{
    public class CommentByStatus<T> : Specification<Comment>
    {
        private readonly short _status;
        public CommentByStatus(short status)
        {
            _status = status;
            expression = x => x.CommentStatus == _status;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
