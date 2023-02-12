﻿using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class DescriptionAccountRepository : IBaseRepository<DescriptionAccount>
    {
        private readonly MessagerDbContext _db;

        public DescriptionAccountRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<DescriptionAccount> createAsync(DescriptionAccount entity)
        {
            var createdEntity = await _db.DescriptionAccounts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> deleteAsync(DescriptionAccount entity)
        {
            _db.DescriptionAccounts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<DescriptionAccount> GetAll()
        {
            return _db.DescriptionAccounts;
        }
    }
}
