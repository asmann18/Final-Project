using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

namespace Atlet.Business.DTOs.E_Commerce.OrderDtos;

public class OrderGetDto:IDto
{
    public int Id { get; init; }
    public bool? IsStatus { get; init; }
    public List<BasketItemGetDto> BasketItems { get; init; }
}
