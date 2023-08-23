

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
        await SaveAsync();
    }

    public void Delete(T entity)
    {
        if(entity is BaseAuditableEntity)
        {
            entity.IsDeleted= true;
            return;
        }
        _context.Set<T>().Remove(entity);


    }

    public IQueryable<T> GetAll(params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }

    public async Task<T> GetByIdAsync(int id, params string[] includes)
    {
            var query=_context.Set<T>().AsQueryable();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(q => q.Id == id);
    }



    public IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression, params string[] includes)
    {
            var query=_context.Set<T>().Where(expression).AsQueryable();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
            var query=_context.Set<T>().AsQueryable();
        foreach (string include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(expression);
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
