using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<T> createAsync(T entity);
        public Task<T> updateAsync(T entity);
        public Task<bool> deleteAsync(T entity);
        public IQueryable<T> GetAll();
    }
}
