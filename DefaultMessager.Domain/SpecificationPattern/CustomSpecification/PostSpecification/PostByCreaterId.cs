using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.SpecificationPattern.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.SpecificationPattern.CustomSpecification.PostSpecification
{
    public class PostByCreaterId<T> : Specification<Post>
    {
        private readonly int _creatorId;
        public PostByCreaterId(int creatorId)
        {
            _creatorId = creatorId;
            expression = post => post.UserId == _creatorId;
        }
        public override Expression<Func<Post, bool>> ToExpression()
        {
            return expression;
        }
    }
}
