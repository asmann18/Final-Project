using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.Core.Entities.E_Commerce;

public class Brand:BaseEntity,IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();


}
