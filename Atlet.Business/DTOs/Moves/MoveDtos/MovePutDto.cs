﻿using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Moves.MoveDtos;

public class MovePutDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int PartId { get; init; }
    public string[] MoveImagePaths { get; init; }
}
