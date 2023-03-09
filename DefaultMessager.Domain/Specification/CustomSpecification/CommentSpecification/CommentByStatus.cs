using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.CommentSpecification
{
    public class CommentByStatus<T> : Specification<Comment>
    {
        private readonly StatusComment _status;
        public CommentByStatus(StatusComment status)
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
