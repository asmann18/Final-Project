using Atlet.Core.Entities.E_Commerce;
using Microsoft.AspNetCore.Identity;

namespace Atlet.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string? Fullname { get; set; }
        ICollection<BasketItem> BasketItems { get; set; }=new List<BasketItem>();
        ICollection<OrderItem> OrderItems { get; set; }=new List<OrderItem>();
        ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
