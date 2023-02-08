using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.ImageAlbumSpecification
{
    public class ImageAlbumById<T> : Specification<ImageAlbum>
    {
        private readonly int _imageAlbumId;
        public ImageAlbumById(int id)
        {
            _imageAlbumId = id;
            expression = post => post.ImageAlbumId == _imageAlbumId;
        }
        public override Expression<Func<ImageAlbum, bool>> ToExpression()
        {
            return expression;
        }
    }
}
