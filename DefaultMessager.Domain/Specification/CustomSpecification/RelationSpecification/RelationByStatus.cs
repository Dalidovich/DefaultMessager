using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.RelationSpecification
{
    public class RelationByStatus<T> : Specification<Relations>
    {
        private readonly StatusRelation _status;
        public RelationByStatus(StatusRelation status)
        {
            _status = status;
            expression = x => x.Status == _status;
        }
        public override Expression<Func<Relations, bool>> ToExpression()
        {
            return expression;
        }
    }
}
