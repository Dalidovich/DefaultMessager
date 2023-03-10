using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.DescriptionAccountModel;
using DefaultMessager.Domain.ViewModel.MessageModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.MessageRepositories
{
    public class MessageNavRepository
    {

        private readonly MessagerDbContext _db;

        public MessageNavRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public IQueryable<MessageViewModel> GetMessageInCorrespondence(Expression<Func<MessageViewModel, bool>>? whereExpression = null)
        {
            var content = _db.Messages.ProjectToType<MessageViewModel>();
            return whereExpression is null ? content : content.Where(whereExpression);
        }
    }
}
