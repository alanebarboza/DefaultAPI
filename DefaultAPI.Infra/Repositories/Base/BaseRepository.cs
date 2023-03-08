using DefaultAPI.Domain.Interfaces.Repositories.Base;
using DefaultAPI.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DefaultAPI.Infra.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DefaultDbContext _context;
        public BaseRepository(DefaultDbContext context) => _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await CommitAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await CommitAsync();
        }

        public async Task<T> FindAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        private async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    }
}
