using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
{
    public class UserById<T> : Specification<User>
    {
        private readonly Guid _userId;
        public UserById(Guid id)
        {
            _userId = id;
            expression = post => post.Id == _userId;
        }
        public override Expression<Func<User, bool>> ToExpression()
        {
            return expression;
        }
    }
}
