﻿using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IBasketItemService
{
    Task<DataResultDto<List<BasketItemGetDto>>> GetAllAsync();
    Task<IResult> AddAsync(BasketItemPostDto dto);
    Task<IResult> DeleteByIdAsync(int id);
    Task<ResultDto> Increase(BasketItemPostDto basketItemPostDto);
    Task<ResultDto> Decrease(BasketItemPostDto basketItemPostDto);
    Task<ResultDto> BuyTheBasket(string? location);
}
