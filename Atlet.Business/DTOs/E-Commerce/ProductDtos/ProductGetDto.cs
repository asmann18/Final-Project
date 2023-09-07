using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.E_Commerce.ManyToMany;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public class ProductGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public int Count { get; init; }
    public int Discount { get; init; }
    public int SalesCount { get; init; }
    public double Rating { get; init; }
    public int ProductCategoryId { get; init; }
    public ProductCategoryRelationDto? ProductCategory { get; init; }
    public int BrandId { get; init; }
    public BrandRelationDto? Brand { get; init; }

    public int AromaId { get; init; }
    public AromaRelationDto? Aroma { get; init; }
    public List<string> ProductImagePaths { get; set; } = new List<string>();


}
