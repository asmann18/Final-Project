using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.Identity;

namespace Atlet.Core.Entities.E_Commerce;

public class BasketItem:BaseEntity,IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Count { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public bool IsSold { get; set; } = false;
}
