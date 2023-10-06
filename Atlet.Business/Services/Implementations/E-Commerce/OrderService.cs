using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Business.Exceptions.E_Commerce.OrderExceptions;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateOrderAsync(List<BasketItem> basketItems)
    {
        Order Order=new Order(basketItems);
        await _orderRepository.CreateAsync(Order);

        return new("Successfully");
      
    }

    public async Task<DataResultDto<List<OrderGetDto>>> GetAllOrderssAsync()
    {
        var Orders =await _orderRepository.GetAll().ToListAsync();
        var orderDtos=_mapper.Map<List<OrderGetDto>>(Orders);
        return new(orderDtos);
    }

    public async Task<DataResultDto<OrderGetDto>> GetOrderByIdAsync(int Id)
    {
        var order=await _orderRepository.GetByIdAsync(Id);
        if (order is null)
            throw new OrderNotFoundException();
        var orderDto=_mapper.Map<OrderGetDto>(order);
        return new(orderDto);
    }

    public async Task<ResultDto> UpdateOrderAsync(OrderPutDto orderPutDto)
    {
        var oldOrder = await _orderRepository.GetByIdAsync(orderPutDto.Id);
        if (oldOrder is null)
            throw new OrderNotFoundException();
        _mapper.Map(oldOrder, orderPutDto);
        return new("Successfully");
    }
}
