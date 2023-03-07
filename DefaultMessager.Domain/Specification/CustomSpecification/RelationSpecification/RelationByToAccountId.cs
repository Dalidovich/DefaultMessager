using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification
{
    public class RelationByToAccountId<T> : Specification<Relations>
    {
        private readonly Guid _id;
        public RelationByToAccountId(Guid id)
        {
            _id = id;
            expression = x => x.AccountId2 == _id;
        }
        public override Expression<Func<Relations, bool>> ToExpression()
        {
            return expression;
        }
    }
}
