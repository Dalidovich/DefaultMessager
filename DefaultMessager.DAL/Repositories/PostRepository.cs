﻿using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly MessagerDbContext _db;

        public PostRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<bool> createAsync(Post entity)
        {
            await _db.Posts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteAsync(Post entity)
        {
            _db.Posts.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Post> GetAll()
        {
            return _db.Posts;
        }
    }
}
