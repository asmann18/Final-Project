using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartPutDto:IDto
{
    public int Id { get; set; }
    public string Name { get; init; }
    public IFormFile? ImageF { get; init; }
}
