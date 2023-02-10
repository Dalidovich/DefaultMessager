using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification
{
    public class DescriptionUserById<T> : Specification<DescriptionAccount>
    {
        private readonly Guid _descriptionUserId;
        public DescriptionUserById(Guid id)
        {
            _descriptionUserId = id;
            expression = post => post.Id == _descriptionUserId;
        }
        public override Expression<Func<DescriptionAccount, bool>> ToExpression()
        {
            return expression;
        }
    }
}
