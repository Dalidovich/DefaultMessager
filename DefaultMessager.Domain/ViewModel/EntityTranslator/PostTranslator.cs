using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.ViewModel.PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.EntityTranslator
{
    public static class PostTranslator
    {

        public static IQueryable<PostIconView> PostListToPostIconViewList(this IQueryable<Post> queryable)
        {
            return queryable.Select(x => new { x.Id, x.AccountId, x.Title, x.PathPictures }).Select(x=>new PostIconView(x.Id,x.AccountId,x.Title,x.PathPictures));
        }
    }
}
