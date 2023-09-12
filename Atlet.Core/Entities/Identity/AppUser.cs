using Atlet.Core.Entities.E_Commerce;
using Microsoft.AspNetCore.Identity;

namespace Atlet.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string? Fullname { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }=new List<BasketItem>();
        public ICollection<OrderItem> OrderItems { get; set; }=new List<OrderItem>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
