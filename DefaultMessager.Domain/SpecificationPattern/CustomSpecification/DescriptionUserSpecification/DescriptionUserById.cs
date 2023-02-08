using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification
{
    public class DescriptionUserById<T> : Specification<DescriptionUser>
    {
        private readonly int _descriptionUserId;
        public DescriptionUserById(int id)
        {
            _descriptionUserId = id;
            expression = post => post.DescriptionId == _descriptionUserId;
        }
        public override Expression<Func<DescriptionUser, bool>> ToExpression()
        {
            return expression;
        }
    }
}
