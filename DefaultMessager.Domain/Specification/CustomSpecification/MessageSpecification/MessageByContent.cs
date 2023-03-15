using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageByContent<T> : Specification<Message>
    {
        private readonly string _content;
        public MessageByContent(string content)
        {
            _content = content;
            expression = x => x.MessageTextContent== _content;
        }
        public override Expression<Func<Message, bool>> ToExpression()
        {
            return expression;
        }
    }
}
