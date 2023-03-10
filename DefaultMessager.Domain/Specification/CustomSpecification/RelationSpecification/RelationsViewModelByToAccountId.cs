using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.RelationModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification
{
    public class RelationsViewModelByToAccountId<T> : Specification<RelationsViewModel>
    {
        private readonly Guid _id;
        public RelationsViewModelByToAccountId(Guid id)
        {
            _id = id;
            expression = x => x.AccountId2 == _id;
        }
        public override Expression<Func<RelationsViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
