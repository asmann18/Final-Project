using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

public class BasketItemPutDto:IDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
}
