using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.Business.DTOs.E_Commerce.Product
{
    public class ProductGetDto:IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public int SalesCount { get; set; }
        public double Rating { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int AromaId { get; set; }
        public Aroma Aroma { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
