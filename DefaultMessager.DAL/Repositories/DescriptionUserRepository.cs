using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class DescriptionUserRepository : IBaseRepository<DescriptionAccount>
    {
        private readonly MessagerDbContext _db;

        public DescriptionUserRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<DescriptionAccount> createAsync(DescriptionAccount entity)
        {
            var createdEntity = await _db.DescriptionUsers.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(DescriptionAccount entity)
        {
            _db.DescriptionUsers.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<DescriptionAccount> GetAll()
        {
            return _db.DescriptionUsers;
        }
    }
}
