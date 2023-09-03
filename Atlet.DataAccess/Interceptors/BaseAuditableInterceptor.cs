using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Atlet.DataAccess.Interceptors;

public class BaseAuditableInterceptor:SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BaseAuditableInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntity(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if(entry.State is EntityState.Added)
            {
                entry.Entity.CreatedTime = DateTime.UtcNow;
                entry.Entity.ModifiedTime = DateTime.UtcNow;
                entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
            }
            if(entry.State is EntityState.Modified)
            {
                entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.ModifiedTime= DateTime.UtcNow;
            }
        }
    }
}
