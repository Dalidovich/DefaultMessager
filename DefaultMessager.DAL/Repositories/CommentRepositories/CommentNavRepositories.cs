using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.CommentModel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.CommentRepositories
{
    public class CommentNavRepositories
    {
        private readonly MessagerDbContext _db;

        public CommentNavRepositories(MessagerDbContext db)
        {
            _db = db;
        }
        public IQueryable<Comment> GetCommentFullInclude(Expression<Func<Comment, bool>>? whereExpression=null)
        {
            var content = _db.Comments.Include(x => x.Post).Include(x => x.Account);
            return whereExpression is null ? content : content.Where(whereExpression);
        }
    }
}
