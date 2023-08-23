using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public class ProductDeleteDto:IDto
{
    public int Id { get; init; }
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
    public ProductImage ProductImage { get; set; }
}
