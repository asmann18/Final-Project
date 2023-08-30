using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;

public class ProductCategoryGetDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public ICollection<ProductRelationDto> Products { get; init; } = new List<ProductRelationDto>();


}
