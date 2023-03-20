using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageBySenderLogin<T> : Specification<Message>
    {
        private readonly string _senderLogin;
        public MessageBySenderLogin(string login)
        {
            _senderLogin = login;
            expression = x => x.Sender.Login == _senderLogin;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
