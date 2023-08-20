using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;

public class ProductCategoryGetDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public ICollection<Product> Products { get; init; } = new List<Product>();


}
