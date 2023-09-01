using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.Identity;

namespace Atlet.Core.Entities.E_Commerce;

public class Basket:BaseAuditableEntity,IEntity
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public AppUser  AppUser  { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    public decimal TotalCount { get; set; }
    public bool IsSold { get; set; } 
}
