using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories.CommentRepositories
{
    public class CommentRepository : IBaseRepository<Comment>
    {
        private readonly MessagerDbContext _db;

        public CommentRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            var createdEntity = await _db.Comments.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Comment entity)
        {
            _db.Comments.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Comment> GetAll()
        {
            return _db.Comments;
        }

        public async Task<Comment> updateAsync(Comment entity)
        {
            var updatedEntity = _db.Comments.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
