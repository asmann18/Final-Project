using Atlet.Core.Abstract.Interfaces;
using Atlet.Core.Entities.Common;

namespace Atlet.Core.Entities.E_Commerce.ManyToMany
{
    public class ProductImage:BaseEntity,IEntity
    {
        public ProductImage(int productId,int imageId)
        {
               ProductId = productId;
            ImageId= imageId;
        }
        public ProductImage()
        {
            
        }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
