namespace Atlet.DataAccess.Repostories.Interfaces;

public interface IRepository<T>where T:BaseEntity,IEntity,new()
{
    IQueryable<T> GetAll(params string[] includes);
    IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T> GetByIdAsync(int id, params string[] includes);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);

    Task<int> SaveAsync();
}
