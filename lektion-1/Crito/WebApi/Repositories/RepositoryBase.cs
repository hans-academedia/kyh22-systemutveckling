using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

namespace WebApi.Repositories
{
    public class RepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public RepositoryBase(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() 
        { 
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
