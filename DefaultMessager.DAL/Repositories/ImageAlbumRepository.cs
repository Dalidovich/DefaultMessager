﻿using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class ImageAlbumRepository : IImageAlbumRepository
    {
        private readonly MessagerDbContext _db;

        public ImageAlbumRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<bool> createAsync(ImageAlbum entity)
        {
            await _db.ImageAlbums.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteAsync(ImageAlbum entity)
        {
            _db.ImageAlbums.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<ImageAlbum> GetAll()
        {
            return _db.ImageAlbums;
        }
    }
}
