using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class BasketItemAutoMapper:Profile
{
    public BasketItemAutoMapper()
    {
        CreateMap<BasketItem, BasketItemPostDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemPutDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemGetDto>().ReverseMap();
    }
}
