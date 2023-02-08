using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.MessageSpecification
{
    public class MessageById<T> : Specification<Message>
    {
        private readonly Guid _MessageId;
        public MessageById(Guid id)
        {
            _MessageId = id;
            expression = post => post.Id == _MessageId;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
