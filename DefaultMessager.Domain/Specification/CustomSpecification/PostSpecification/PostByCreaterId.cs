using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification
{
    public class PostByCreaterId<T> : Specification<Post>
    {
        private readonly Guid _creatorId;
        public PostByCreaterId(Guid creatorId)
        {
            _creatorId = creatorId;
            expression = x => x.AccountId == _creatorId;
        }
        public override Expression<Func<Post, bool>> ToExpression()
        {
            return expression;
        }
    }
}
