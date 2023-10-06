using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandPutDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public IFormFile ImageF { get; init; }
}
