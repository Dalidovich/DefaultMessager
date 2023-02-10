﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.ImageAlbumSpecification
{
    public class ImageAlbumById<T> : Specification<ImageAlbum>
    {
        private readonly Guid _imageAlbumId;
        public ImageAlbumById(Guid id)
        {
            _imageAlbumId = id;
            expression = x => x.Id == _imageAlbumId;
        }
        public override Expression<Func<ImageAlbum, bool>> ToExpression()
        {
            return expression;
        }
    }
}
