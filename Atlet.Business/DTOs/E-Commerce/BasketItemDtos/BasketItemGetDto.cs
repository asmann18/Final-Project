using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;

namespace Atlet.Business.DTOs.E_Commerce.BasketItemDtos;

public class BasketItemGetDto:IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductRelationDto Product { get; set; }
    public int Count { get; set; }
    public string AppUserId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
    //public bool IsDeleted { get; set; }
}
