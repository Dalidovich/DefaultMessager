using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly MessagerDbContext _db;

        public LikeRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<bool> createAsync(Like entity)
        {
            await _db.Likes.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteAsync(Like entity)
        {
            _db.Likes.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Like> GetAll()
        {
            return _db.Likes;
        }
    }
}
