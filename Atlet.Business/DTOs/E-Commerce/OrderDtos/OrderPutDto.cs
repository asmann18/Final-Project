using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.OrderDtos;

public class OrderPutDto:IDto
{
    public int Id { get; set; }
    public bool? IsStatus { get; set; }
}
