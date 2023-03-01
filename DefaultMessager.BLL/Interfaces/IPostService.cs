using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.PostModel;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IPostService
    {
        Task<BaseResponse<IEnumerable<PostIconViewModel>>> GetPostIcons(int skipCount, int count, Expression<Func<PostIconViewModel, bool>>? expression = null);
        Task<BaseResponse<IEnumerable<Post>>> GetFullPosts(Expression<Func<Post, bool>>? whereExpression);
    }
}
