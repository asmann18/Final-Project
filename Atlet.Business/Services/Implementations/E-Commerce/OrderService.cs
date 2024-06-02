using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.OrderExceptions;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.E_Commerce.ManyToMany;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly bool _isAuthenticated;
    private const string COOKIE_BASKET_ITEM_KEY = "mybasketitemkey";
    private readonly IProductService _productService;

    public OrderService(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductService productService)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        _productService = productService;
    }

    public async Task<DataResultDto<OrderGetDto>> CreateOrderAsync(List<BasketItem> basketItems, string? location)
    {
        Order Order;
        if (location is not null)
        {
            Order = new Order(basketItems, location);

        }
        else
        {
            Order = new Order(basketItems);
        }
        await _orderRepository.CreateAsync(Order);

        var dto = _mapper.Map<OrderGetDto>(Order);

        return new(dto);

    }

    public async Task<DataResultDto<List<OrderGetDto>>> GetAllOrderssAsync()
    {
        var Orders = await _orderRepository.GetAll().OrderByDescending(x => x.ModifiedTime).ToListAsync();
        var orderDtos = _mapper.Map<List<OrderGetDto>>(Orders);
        return new(orderDtos);
    }


    public async Task<ResultDto> ChangeOrderStatus(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
            throw new OrderNotFoundException();
        if (order.IsStatus is false)
            order.IsStatus = null;
        else if (order.IsStatus is null)
            order.IsStatus = true;
        await _orderRepository.SaveAsync();
        return new("successfully updated");
    }
    public async Task<ResultDto> ChangeOrderStatusReverse(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
            throw new OrderNotFoundException();
        if (order.IsStatus is true)
            order.IsStatus = null;
        else if (order.IsStatus is null)
            order.IsStatus = false;
        await _orderRepository.SaveAsync();
        return new("successfully updated");
    }
    public async Task<ResultDto> ChangeOrderStatus(int id, bool? status)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
            throw new OrderNotFoundException();
        order.IsStatus = status;
        await _orderRepository.SaveAsync();
        return new("successfully updated");

    }
    public async Task<DataResultDto<OrderGetDto>> GetOrderByIdAsync(int Id)
    {
        var order = await _orderRepository.GetByIdAsync(Id, "BasketItems");

        if (order is null)
            throw new OrderNotFoundException();
        var orderDto = _mapper.Map<OrderGetDto>(order);
        foreach (var basketItem in orderDto.BasketItems)
        {

            var product = _mapper.Map<ProductRelationDto>((await _productService.GetProductByIdAsync(basketItem.ProductId)).data);
            basketItem.Product = product;
        }

        return new(orderDto);
    }

    public async Task<DataResultDto<List<OrderGetDto>>> GetUserOrders()
    {
        var id = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var orders = await _orderRepository.GetFiltered(o => o.AppUserId == id, "BasketItems").OrderByDescending(o => o.CreatedTime).ToListAsync();
        if (orders is null)
        {
            throw new OrderNotFoundException();
        }
        var orderDtos = _mapper.Map<List<OrderGetDto>>(orders);

        foreach (var order in orderDtos)
        {
            foreach (var basketItem in order.BasketItems)
            {

                var product = _mapper.Map<ProductRelationDto>((await _productService.GetProductByIdAsync(basketItem.ProductId)).data);
                basketItem.Product = product;
            }
        }
        return new(orderDtos);
    }

    public async Task<ResultDto> UpdateOrderAsync(OrderPutDto orderPutDto)
    {
        var oldOrder = await _orderRepository.GetByIdAsync(orderPutDto.Id);
        if (oldOrder is null)
            throw new OrderNotFoundException();
        _mapper.Map(oldOrder, orderPutDto);
        await _orderRepository.SaveAsync();
        return new("Successfully");
    }
    public async Task<ResultDto> DeleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
            throw new OrderNotFoundException();
        order.IsDeleted = !order.IsDeleted;
        _orderRepository.Update(order);
        await _orderRepository.SaveAsync();
        return new("Successfully");
    }
}
