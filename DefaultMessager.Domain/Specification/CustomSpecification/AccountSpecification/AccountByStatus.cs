using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification
{
    public class AccountByStatus<T> : Specification<Account>
    {
        private readonly StatusAccount _status;
        public AccountByStatus(StatusAccount status)
        {
            _status = status;
            expression = x => x.StatusAccount == _status;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
