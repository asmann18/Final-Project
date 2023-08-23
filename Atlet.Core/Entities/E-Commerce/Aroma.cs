using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce;

public class Aroma:BaseEntity,IEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }= new List<Product>();

}
