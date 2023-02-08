using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly MessagerDbContext _db;

        public UserRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<User> createAsync(User entity)
        {
            var createdEntity = await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

    }
}
