using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.MessageModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageViewModelBySenderId<T> : Specification<MessageViewModel>
    {
        private readonly Guid _senderId;
        public MessageViewModelBySenderId(Guid id)
        {
            _senderId = id;
            expression = x => x.SenderId == _senderId;
        }
        public override Expression<Func<MessageViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
