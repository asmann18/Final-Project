using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.Moves;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartPutDto:IDto
{
    public int Id { get; set; }
    public string Name { get; init; }
    public string ImagePath { get; init; }
}
