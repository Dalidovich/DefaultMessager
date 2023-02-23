using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.BLL.Base
{
    public interface IBaseService<T>
    {
        Task<BaseResponse<T>> GetOne(Expression<Func<T, bool>> expression);
        Task<BaseResponse<IEnumerable<T>>> GetAll();
        Task<BaseResponse<IEnumerable<T>>> GetAllSatisfactory(Expression<Func<T, bool>> expression);
        Task<BaseResponse<bool>> Delete(Expression<Func<T, bool>> expression);
        Task<BaseResponse<T>> Create(T entity);
        Task<BaseResponse<T>> Update(T entity);
    }
}
