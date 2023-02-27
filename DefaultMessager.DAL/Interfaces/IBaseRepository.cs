namespace DefaultMessager.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<T> AddAsync(T entity);
        public Task<T> updateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public IQueryable<T> GetAll();
    }
}
