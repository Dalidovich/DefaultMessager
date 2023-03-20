using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.DAL.Repositories.RelationsRepositories
{
    public class RelationsRepository : IBaseRepository<Relations>
    {
        private readonly MessagerDbContext _db;

        public RelationsRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<Relations> AddAsync(Relations entity)
        {
            var createdEntity = await _db.Relations.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Relations entity)
        {
            _db.Relations.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Relations> GetAll()
        {
            return _db.Relations;
        }

        public async Task<Relations> updateAsync(Relations entity)
        {
            var updatedEntity = _db.Relations.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
