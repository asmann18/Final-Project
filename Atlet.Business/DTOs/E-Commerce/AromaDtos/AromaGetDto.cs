using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.DTOs.E_Commerce.AromaDtos;

public class AromaGetDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<ProductRelationDto> Products { get; init; } = new List<ProductRelationDto>();

}
