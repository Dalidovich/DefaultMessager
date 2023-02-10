using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.UserSpecification
{
    public class AccountByStatus<T> : Specification<Account>
    {
        private readonly short _status;
        public AccountByStatus(short staus)
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
