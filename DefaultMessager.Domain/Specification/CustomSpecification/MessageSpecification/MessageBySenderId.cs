using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.MessageSpecification
{
    public class MessageBySenderId<T> : Specification<Message>
    {
        private readonly Guid _senderId;
        public MessageBySenderId(Guid id)
        {
            _senderId = id;
            expression = x => x.SenderId == _senderId;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
