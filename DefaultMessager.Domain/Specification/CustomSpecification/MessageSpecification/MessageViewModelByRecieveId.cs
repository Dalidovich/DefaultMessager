using DefaultMessager.Domain.Specification.Base;
using DefaultMessager.Domain.ViewModel.MessageModel;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification
{
    public class MessageViewModelByRecieveId<T> : Specification<MessageViewModel>
    {
        private readonly Guid _recieveId;
        public MessageViewModelByRecieveId(Guid id)
        {
            _recieveId = id;
            expression = x => x.RecieveId == _recieveId;
        }
        public override Expression<Func<MessageViewModel, bool>> ToExpression()
        {
            return expression;
        }
    }
}
