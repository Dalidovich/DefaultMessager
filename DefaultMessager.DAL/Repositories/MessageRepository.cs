using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class MessageRepository : IBaseRepository<Message>
    {
        private readonly MessagerDbContext _db;

        public MessageRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Message> createAsync(Message entity)
        {
            var createdEntity = await _db.Messages.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(Message entity)
        {
            _db.Messages.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Message> GetAll()
        {
            return _db.Messages;
        }

        public async Task<Message> updateAsync(Message entity)
        {
            var updatedEntity = _db.Messages.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
