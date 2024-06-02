using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartPostDto:IDto
{

    public string Name { get; init; }
    public IFormFile ImageF { get; init; }
}
