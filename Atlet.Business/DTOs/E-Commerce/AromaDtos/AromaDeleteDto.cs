﻿using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.AromaDtos;

public class AromaDeleteDto:IDto
{

    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<Product> Products { get; init; } = new List<Product>();
}
