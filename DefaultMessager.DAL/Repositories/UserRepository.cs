using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class UserRepository : IBaseRepository<Account>
    {
        private readonly MessagerDbContext _db;

        public UserRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Account> createAsync(Account entity)
        {
            var createdEntity = await _db.Accounts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(Account entity)
        {
            _db.Accounts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Account> GetAll()
        {
            return _db.Accounts;
        }

    }
}
