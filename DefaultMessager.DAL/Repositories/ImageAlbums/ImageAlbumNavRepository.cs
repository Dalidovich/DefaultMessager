using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DefaultMessager.DAL.Repositories.ImageAlbums
{
    public class ImageAlbumNavRepository
    {
        private readonly MessagerDbContext _db;

        public ImageAlbumNavRepository(MessagerDbContext db)
        {
            _db = db;
        }

        public IQueryable<ImageAlbum> GetImageAlbumFullInclude(Expression<Func<ImageAlbum, bool>>? whereExpression = null)
        {
            var content = _db.ImageAlbums.Include(x => x.Account);
            return whereExpression is null ? content : content.Where(whereExpression);
        }
    }
}
