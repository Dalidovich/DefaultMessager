using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.RelationModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification
{
    public class RelationViewModelByFromAccountId<T> : Specification<RelationsViewModel>
    {
        private readonly Guid _id;
        public RelationViewModelByFromAccountId(Guid id)
        {
            _id = id;
            expression = x => x.AccountId1 == _id;
        }
        public override Expression<Func<RelationsViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
