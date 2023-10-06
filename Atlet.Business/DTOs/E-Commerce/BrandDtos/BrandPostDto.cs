using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandPostDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public IFormFile ImageF { get; init; }
}
