using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories.PostRepositories
{
    public class PostRepository : IBaseRepository<Post>
    {
        private readonly MessagerDbContext _db;

        public PostRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Post> AddAsync(Post entity)
        {
            var createdEntity = await _db.Posts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Post entity)
        {
            _db.Posts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Post> GetAll()
        {
            return _db.Posts;
        }

        public async Task<Post> updateAsync(Post entity)
        {
            var updatedEntity = _db.Posts.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
