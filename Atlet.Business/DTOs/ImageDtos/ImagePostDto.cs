using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.ImageDtos;

public class ImagePostDto:IDto
{
    public IFormFile Path { get; init; }
    public string Alt { get; init; } = "img";
}
