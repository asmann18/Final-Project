using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

public class BasketItemGetDto:IDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
    public int AppUserId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    public bool IsDeleted { get; set; }
}
