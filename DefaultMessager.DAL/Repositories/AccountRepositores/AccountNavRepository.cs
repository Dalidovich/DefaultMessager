using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.AccountRepositores
{
    public class AccountNavRepository
    {

        private readonly MessagerDbContext _db;

        public AccountNavRepository(MessagerDbContext db)
        {
            _db = db;
        }
        public IQueryable<AccountAuthenticateViewModel> GetIncludeDescribeAndRefreshToken(Expression<Func<AccountAuthenticateViewModel, bool>> whereExpression)
        {
            return _db.Accounts.ProjectToType<AccountAuthenticateViewModel>().Where(whereExpression);
        }
    }
}
