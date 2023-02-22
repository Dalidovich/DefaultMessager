using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IPostService
    {
        Task<BaseResponse<IEnumerable<PostIconViewModel>>> GetPostIcons(int skipCount,int count);
        Task<BaseResponse<IEnumerable<Post>>> GetFullPosts(Expression<Func<Post, bool>>? whereExpression);
    }
}
