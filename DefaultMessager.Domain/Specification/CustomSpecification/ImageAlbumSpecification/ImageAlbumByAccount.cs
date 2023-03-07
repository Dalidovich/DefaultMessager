using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.ImageAlbumSpecification
{
    public class ImageAlbumByAccount<T> : Specification<ImageAlbum>
    {
        private readonly Guid _accountId;
        public ImageAlbumByAccount(Guid id)
        {
            _accountId = id;
            expression = x => x.AccountId == _accountId;
        }
        public override Expression<Func<ImageAlbum, bool>> ToExpression()
        {
            return expression;
        }
    }
}
