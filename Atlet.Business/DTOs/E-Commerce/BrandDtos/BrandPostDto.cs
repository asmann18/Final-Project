using Atlet.Business.DTOs.Abstract;
namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandPostDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int ImageId { get; init; }
}
