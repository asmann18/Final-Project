using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IOrderService
{
    Task<DataResultDto<List<OrderGetDto>>> GetAllOrderssAsync();
    Task<DataResultDto<OrderGetDto>> GetOrderByIdAsync(int Id);
    Task<ResultDto> CreateOrderAsync(List<BasketItem> basketItems);
    Task<ResultDto> UpdateOrderAsync(OrderPutDto orderPutDto);
}
