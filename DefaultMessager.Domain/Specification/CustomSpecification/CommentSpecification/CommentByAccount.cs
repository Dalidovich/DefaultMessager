using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification
{
    public class CommentByAccount<T> : Specification<Comment>
    {
        private readonly Guid _accountId;
        public CommentByAccount(Guid id)
        {
            _accountId = id;
            expression = x => x.AccountId == _accountId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
