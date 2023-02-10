﻿using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.CommentSpecification
{
    public class CommentByPostId<T> : Specification<Comment>
    {
        private readonly Guid _postId;
        public CommentByPostId(Guid id)
        {
            _postId = id;
            expression = x => x.PostId == _postId;
        }
        public override Expression<Func<Comment, bool>> ToExpression()
        {
            return expression;
        }
    }
}
