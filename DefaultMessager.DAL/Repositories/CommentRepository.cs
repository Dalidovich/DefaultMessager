using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.DAL.Repositories
{
    public class CommentRepository : IBaseRepository<Comment>
    {
        private readonly MessagerDbContext _db;

        public CommentRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Comment> createAsync(Comment entity)
        {
            var createdEntity = await _db.Comments.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(Comment entity)
        {
            _db.Comments.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Comment> GetAll()
        {
            return _db.Comments;
        }
    }
}
