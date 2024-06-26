﻿using Atlet.Business.DTOs.Abstract;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public class ProductPutDto:IDto
{
    public int Id{ get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public double Price { get; init; }
    public int Count { get; init; }
    public int Discount { get; init; }
    public int ProductCategoryId { get; init; }
    public int BrandId { get; init; }

    public int AromaId { get; init; }
    public IFormFile[]? ProductImagesF { get; init; }

}
