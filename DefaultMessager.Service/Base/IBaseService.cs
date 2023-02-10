using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Service.Base
{
    public interface IBaseService<T>
    {
        Task<IBaseResponse<T>> GetOne(Expression<Func<T, bool>> expression);
        Task<IBaseResponse<IEnumerable<T>>> GetAll();
        Task<IBaseResponse<IEnumerable<T>>> GetAllSatisfactory(Expression<Func<T, bool>> expression);
        Task<IBaseResponse<bool>> Delete(Expression<Func<T, bool>> expression);
        Task<IBaseResponse<T>> Create(T entity);
    }
}
