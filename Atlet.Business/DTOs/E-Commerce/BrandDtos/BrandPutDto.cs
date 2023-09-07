using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandPutDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string ImagePath { get; init; }
}
