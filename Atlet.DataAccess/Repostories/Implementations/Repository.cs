using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.DataAccess.Contexts;
using Atlet.DataAccess.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atlet.DataAccess.Repostories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, IEntity, new()
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
            _context= context;
    }
    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
        if(entity is BaseAuditableEntity)
        {
            (BaseAuditableEntity)entity.IsDeleted
        }
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
      return  _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
    }

    public IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }


    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
