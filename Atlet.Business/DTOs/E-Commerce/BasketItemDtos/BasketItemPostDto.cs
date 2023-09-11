using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

public class BasketItemPostDto:IDto
{
    public int Count { get; set; }
    public int ProductId { get; set; }
}
