using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageByRecieveId<T> : Specification<Message>
    {
        private readonly Guid _recieveId;
        public MessageByRecieveId(Guid id)
        {
            _recieveId = id;
            expression = x => x.RecieveId == _recieveId;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
