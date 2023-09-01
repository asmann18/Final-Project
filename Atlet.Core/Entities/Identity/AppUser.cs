using Atlet.Core.Entities.E_Commerce;
using Microsoft.AspNetCore.Identity;

namespace Atlet.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string? Fullname { get; set; }
        ICollection<Basket> Baskets { get; set; }=new List<Basket>();
        ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
