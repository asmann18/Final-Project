using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class OrderAutoMapper:Profile
{
    public OrderAutoMapper()
    {
        CreateMap<Order, OrderGetDto>().ReverseMap();
    }

}
