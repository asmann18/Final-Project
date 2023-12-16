using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

namespace Atlet.Business.DTOs.E_Commerce.OrderDtos;

public class OrderGetDto:IDto
{
    public int Id { get; init; }
    public bool? IsStatus { get; init; }
    public DateTime CreatedTime { get; set; }
    public List<BasketItemGetDto> BasketItems { get; init; } = new();
    public bool IsDelivery { get; init; }
    public string? Location { get; init; }
    public double TotalPrice { get; init; }
    public bool IsDeleted  { get; set; }
    public string CreatedBy { get; set; }
}
