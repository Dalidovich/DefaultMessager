using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification
{
    public class DescriptionAccountById<T> : Specification<DescriptionAccount>
    {
        private readonly Guid _descriptionUserId;
        public DescriptionAccountById(Guid id)
        {
            _descriptionUserId = id;
            expression = x => x.Id == _descriptionUserId;
        }
        public override Expression<Func<DescriptionAccount, bool>> ToExpression()
        {
            return expression;
        }
    }
}
