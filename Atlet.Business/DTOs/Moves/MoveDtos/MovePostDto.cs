using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves.ManyToMany;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MovePostDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int PartId { get; init; }
    public IFormFile[] MoveImagesF { get; init; }
}
