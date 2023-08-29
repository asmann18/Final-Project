﻿using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.BrandDtos;

public class BrandGetDto:IDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public int ImageId { get; init; }
    public ICollection<Product> Products { get; init; } = new List<Product>();
}
