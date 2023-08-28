using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.ImageDtos;

public class ImagePutDto:IDto
{
    public int Id { get; init; }
    public IFormFile? Path { get; init; }
    public string Alt { get; init; } 
}
