using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories.AccountRepositores
{
    public class AccountRepository : IBaseRepository<Account>
    {
        private readonly MessagerDbContext _db;

        public AccountRepository(MessagerDbContext db)
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

        public async Task<Account> updateAsync(Account entity)
        {
            var updatedEntity = _db.Accounts.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
