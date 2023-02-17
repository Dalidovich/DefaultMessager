using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaultMessager.DAL.Repositories
{
    public class RefreshTokenRepository : IBaseRepository<RefreshToken>
    {
        private readonly MessagerDbContext _db;

        public RefreshTokenRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<RefreshToken> createAsync(RefreshToken entity)
        {
            var createdEntity = await _db.RefreshTokens.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }
        public async Task<bool> deleteAsync(RefreshToken entity)
        {
            _db.RefreshTokens.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<RefreshToken> GetAll()
        {
            return _db.RefreshTokens;
        }

        public async Task<RefreshToken> updateAsync(RefreshToken entity)
        {
            var updatedEntity = _db.RefreshTokens.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
