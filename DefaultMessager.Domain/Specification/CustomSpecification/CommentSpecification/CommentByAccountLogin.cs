using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.CommentSpecification
{
    public class CommentByAccountLogin<T> : Specification<Comment>
    {
        private readonly string _login;
        public CommentByAccountLogin(string login)
        {
            _login = login;
            expression = x => x.Account.Login == _login;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
