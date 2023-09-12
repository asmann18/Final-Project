using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Claims;

namespace Atlet.DataAccess.Interceptors;

internal class CommentInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CommentInterceptor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateCartItem(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private void UpdateCartItem(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<Comment>())
        {
            entry.Entity.AppUserID = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}