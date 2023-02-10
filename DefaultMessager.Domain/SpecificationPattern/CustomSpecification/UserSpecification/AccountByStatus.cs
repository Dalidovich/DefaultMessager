using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
{
    public class AccountByStatus<T> : Specification<Account>
    {
        private readonly StatusAccount _status;
        public AccountByStatus(StatusAccount staus)
        {
            _status = staus;
            expression = x => x.StatusAccount == _status;
        }
        public override Expression<Func<Account, bool>> ToExpression()
        {
            return expression;
        }
    }
}
