using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountProfileById<T> : Specification<AccountProfileViewModel>
    {
        private readonly Guid _id;
        public AccountProfileById(Guid id)
        {
            _id= id;
            expression = x => x.Id == _id;
        }
        public override Expression<Func<AccountProfileViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
