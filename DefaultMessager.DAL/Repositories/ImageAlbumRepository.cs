using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;

namespace DefaultMessager.DAL.Repositories
{
    public class ImageAlbumRepository : IBaseRepository<ImageAlbum>
    {
        private readonly MessagerDbContext _db;

        public ImageAlbumRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public async Task<ImageAlbum> AddAsync(ImageAlbum entity)
        {
            var createdEntity = await _db.ImageAlbums.AddAsync(entity);
            await _db.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(ImageAlbum entity)
        {
            _db.ImageAlbums.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<ImageAlbum> GetAll()
        {
            return _db.ImageAlbums;
        }

        public async Task<ImageAlbum> updateAsync(ImageAlbum entity)
        {
            var updatedEntity = _db.ImageAlbums.Update(entity);
            await _db.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
