using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlet.Core.Entities.E_Commerce
{
    public class ProductCategory:BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
