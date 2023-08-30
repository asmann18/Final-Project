﻿using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public class ProductRelationDto:IDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public int Count { get; init; }
    public int Discount { get; init; }
    public int SalesCount { get; init; }
    public double Rating { get; init; }
}
