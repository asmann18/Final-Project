﻿using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Moves.PartDtos;

public class PartPostDto:IDto
{

    public string Name { get; init; }
    public string ImagePath { get; init; }
}
