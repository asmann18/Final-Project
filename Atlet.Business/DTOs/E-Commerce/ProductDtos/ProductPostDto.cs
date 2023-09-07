using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;
public class ProductPostDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public int Discount { get; set; }
    public int ProductCategoryId { get; set; }
    public int BrandId { get; set; }
    public int AromaId { get; set; }
    public string[] ProductImagePaths { get; set; }
}
