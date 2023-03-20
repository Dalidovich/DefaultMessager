using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountIconViewModelById<T> : Specification<AccountIconViewModel>
    {
        private readonly Guid _accountId;
        public AccountIconViewModelById(Guid id)
        {
            _accountId = id;
            expression = x => x.Id == _accountId;
        }
        public override Expression<Func<AccountIconViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
