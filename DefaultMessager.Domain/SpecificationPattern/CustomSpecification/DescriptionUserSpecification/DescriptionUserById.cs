using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification
{
    public class DescriptionUserById<T> : Specification<DescriptionUser>
    {
        private readonly Guid _descriptionUserId;
        public DescriptionUserById(Guid id)
        {
            _descriptionUserId = id;
            expression = post => post.Id == _descriptionUserId;
        }
        public override Expression<Func<DescriptionUser, bool>> ToExpression()
        {
            return expression;
        }
    }
}
