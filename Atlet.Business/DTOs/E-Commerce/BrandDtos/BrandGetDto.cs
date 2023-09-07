using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.DTOs.ImageDtos;
using Atlet.Core.Entities;

namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string ImageId { get; init; }
    public ImageGetDto Image { get; set; }
    public ICollection<ProductRelationDto> Products { get; init; } = new List<ProductRelationDto>();
}
