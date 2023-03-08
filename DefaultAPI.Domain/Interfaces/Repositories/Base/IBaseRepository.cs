namespace DefaultAPI.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> FindAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
