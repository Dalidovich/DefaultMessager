using DefaultMessager.Domain.Response.Base;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Base
{
    public interface IBaseService<T>
    {
        Task<BaseResponse<T>> GetOne(Expression<Func<T, bool>> expression);
        Task<BaseResponse<IEnumerable<T>>> GetAll();
        Task<BaseResponse<IEnumerable<T>>> GetAllSatisfactory(Expression<Func<T, bool>> expression);
        Task<BaseResponse<bool>> Delete(Expression<Func<T, bool>> expression);
        Task<BaseResponse<T>> Add(T entity);
        Task<BaseResponse<T>> Update(T entity);
    }
}
