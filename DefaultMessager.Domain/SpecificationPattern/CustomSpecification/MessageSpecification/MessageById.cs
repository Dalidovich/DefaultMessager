using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.MessageSpecification
{
    public class MessageById<T> : Specification<Message>
    {
        private readonly int _MessageId;
        public MessageById(int id)
        {
            _MessageId = id;
            expression = post => post.MessageId == _MessageId;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
