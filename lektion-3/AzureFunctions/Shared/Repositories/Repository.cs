using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Shared.Repositories;

public class Repository<TEntity, TContext> where TEntity : class where TContext : DbContext
{
    private readonly TContext _context;

    public Repository(TContext context)
    {
        _context = context;
    }


    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var _entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return _entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
