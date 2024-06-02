using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IOrderService
{
    Task<DataResultDto<List<OrderGetDto>>> GetAllOrderssAsync();
    Task<DataResultDto<OrderGetDto>> GetOrderByIdAsync(int Id);
    Task<DataResultDto<OrderGetDto>> CreateOrderAsync(List<BasketItem> basketItems,string? location);
    Task<ResultDto> ChangeOrderStatus(int id);
    Task<ResultDto> ChangeOrderStatusReverse(int id);
    Task<ResultDto> ChangeOrderStatus(int id,bool? status);

    Task<ResultDto> UpdateOrderAsync(OrderPutDto orderPutDto);
    Task<DataResultDto<List<OrderGetDto>>> GetUserOrders();


    Task<ResultDto> DeleteOrderAsync(int id);

}
