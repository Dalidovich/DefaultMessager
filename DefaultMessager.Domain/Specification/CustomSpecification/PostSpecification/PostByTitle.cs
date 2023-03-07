using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Specification.Base;
using System.Linq.Expressions;

namespace DefaultMessager.Domain.Specification.CustomSpecification.PostSpecification
{
    public class PostByTitle<T> : Specification<Post>
    {
        private readonly string _title;
        public PostByTitle(string title)
        {
            _title = title;
            expression = x => x.Title == _title;
        }
        public override Expression<Func<Post, bool>> ToExpression()
        {
            return expression;
        }
    }
}
