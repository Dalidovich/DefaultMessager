using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageById<T> : Specification<Message>
    {
        private readonly Guid _messageId;
        public MessageById(Guid id)
        {
            _messageId = id;
            expression = x => x.Id == _messageId;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
