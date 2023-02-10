using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.ImageAlbumSpecification
{
    public class ImageAlbumByTitle<T> : Specification<ImageAlbum>
    {
        private readonly string _title;
        public ImageAlbumByTitle(string title)
        {
            _title = title;
            expression = x => x.Title == _title;
        }
        public override Expression<Func<ImageAlbum, bool>> ToExpression()
        {
            return expression;
        }
    }
}
