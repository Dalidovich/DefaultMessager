using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.RelationModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification
{
    public class RelationsViewModelByStatus<T> : Specification<RelationsViewModel>
    {
        private readonly StatusRelation _status;
        public RelationsViewModelByStatus(StatusRelation status)
        {
            _status = status;
            expression = x => x.Status == _status;
        }
        public override Expression<Func<RelationsViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
