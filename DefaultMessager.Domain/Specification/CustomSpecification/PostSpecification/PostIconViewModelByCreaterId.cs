using DefaultMessager.Domain.SpecificationPattern.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification
{
    public class PostIconViewModelByCreaterId<T> : Specification<PostIconViewModel>
    {
        private readonly Guid _creatorId;
        public PostIconViewModelByCreaterId(Guid creatorId)
        {
            _creatorId = creatorId;
            expression = x => x.AccountViewModel.Id == _creatorId;
        }
        public override Expression<Func<PostIconViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
