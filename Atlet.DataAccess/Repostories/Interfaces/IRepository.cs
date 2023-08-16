using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using System.Linq.Expressions;

namespace Atlet.DataAccess.Repostories.Interfaces;

public interface IRepository<T>where T:BaseEntity,IEntity,new()
{
    IQueryable<T> GetAll();
    IQueryable<T> GetFiltered(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> expression);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    Task<int> SaveAsync();
}
