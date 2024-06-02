using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;
using Atlet.Business.DTOs.E_Commerce.OrderDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.BasketItemExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class BasketItemService : IBasketItemService
{
    private readonly IBasketItemRepository _basketItemRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly bool _isAuthenticated;
    private const string COOKIE_BASKET_ITEM_KEY = "mybasketitemkey";
    private readonly IOrderService _orderService;
    private readonly IImageService _imageService;
    private readonly IProductService _productService;

    public BasketItemService(IHttpContextAccessor contextAccessor, IMapper mapper, IBasketItemRepository basketItemRepository, IOrderService orderService, IImageService imageService, IProductService productService)
    {
        _contextAccessor = contextAccessor;
        _mapper = mapper;
        _basketItemRepository = basketItemRepository;
        _isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        _orderService = orderService;
        _imageService = imageService;
        _productService = productService;
    }


    public async Task<IResult> AddAsync(BasketItemPostDto dto)
    {
        var basketItem = _mapper.Map<BasketItem>(dto);
        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ExistBasketItem = _basketItemRepository.GetFiltered(i => i.ProductId == dto.ProductId && i.AppUserId == id && !i.IsSold,"Product" ).ToList().FirstOrDefault();
            if (ExistBasketItem is null)
            {
                await _basketItemRepository.CreateAsync(basketItem);
                return new ResultDto("product successfully added");
            }


            if (ExistBasketItem.Product.Count >= ExistBasketItem.Count+dto.Count )
            {
                ExistBasketItem.Count += dto.Count;
            }
            else
            {
                ExistBasketItem.Count = ExistBasketItem.Product.Count;
            }

            _basketItemRepository.Update(ExistBasketItem);
            await _basketItemRepository.SaveAsync();      
        
        }
        else
        {
            await AddBasketItemToCookieAsync(basketItem);

        }

        return new ResultDto("product successfully added");
        
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {

        if (_isAuthenticated)
        {
            var BasketItem = await _basketItemRepository.GetByIdAsync(id, "Product");
            if (BasketItem is null)
                throw new BasketItemNotFoundException();
            if (BasketItem.AppUserId == _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                if (BasketItem.IsSold is true)
                    throw new BasketItemCannotBeDeletedException();

                _basketItemRepository.Delete(BasketItem);
                await _basketItemRepository.SaveAsync();
                return new ResultDto("BasketItem is successfully deleted");
            }
            else
                throw new BasketItemCannotBeDeletedException("You cannot delete other users' products");
        }

        await RemoveBasketItemToCookieAsync(id);
        return new ResultDto("Product is removed");
    }

    public async Task<DataResultDto<List<BasketItemGetDto>>> GetAllAsync()
    {
        if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var basketItems = await _basketItemRepository.GetFiltered(i => i.AppUserId == id && i.IsSold == false, "AppUser","Product").ToListAsync();
            var itemDtos=_mapper.Map<List<BasketItemGetDto>>(basketItems);
            foreach (var item in itemDtos)
            {
                item.Product.ProductImagePaths=await _imageService.GetProductImageUrlsByIdAsync(item.ProductId);
            }
            return new DataResultDto<List<BasketItemGetDto>>(itemDtos);
        }
        var CookieBasketItems= GetBasketItemsFromCookie();
        var cookieDtos = _mapper.Map<List<BasketItemGetDto>>(CookieBasketItems);
        return new DataResultDto<List<BasketItemGetDto>> ( cookieDtos );
    }



    
    private async Task AddBasketItemToCookieAsync(BasketItem item)
    {
        List<BasketItem> cartItems = GetBasketItemsFromCookie();
        if (cartItems != null)
            if (cartItems.Any(c => c.ProductId == item.ProductId))
                cartItems.FirstOrDefault(c => c.ProductId == item.ProductId)!.Count += item.Count;
            else
                cartItems.Add(item);
        else
            cartItems = new List<BasketItem> { item };

        _contextAccessor.HttpContext.Response.Cookies.Append(COOKIE_BASKET_ITEM_KEY, JsonConvert.SerializeObject(cartItems));
        //HttpResponseMessage message = new HttpResponseMessage();
        //var cookie = new CookieHeaderValue("Test", "Value");
        //message.Headers.AddCookies()
    }
    private async Task RemoveBasketItemToCookieAsync(int id)
    {
        List<BasketItem> cartItems = GetBasketItemsFromCookie();
        if (cartItems is not null)
        {
            var deletedItem = cartItems.Where(i => i.Id == id).FirstOrDefault();
            if (deletedItem is null)
                throw new BasketItemNotFoundException();
            cartItems.Remove(deletedItem);
            _contextAccessor.HttpContext.Response.Cookies.Delete(COOKIE_BASKET_ITEM_KEY);
            _contextAccessor.HttpContext.Response.Cookies.Append(COOKIE_BASKET_ITEM_KEY, JsonConvert.SerializeObject(cartItems));
            return;
        }
        else 
            throw new BasketIsEmptyException();
    }
    private List<BasketItem> GetBasketItemsFromCookie()
    {
        List<BasketItem> cartItems = null;
        if (_contextAccessor.HttpContext.Request.Cookies[COOKIE_BASKET_ITEM_KEY] != null)
            cartItems = JsonConvert.DeserializeObject<List<BasketItem>>(_contextAccessor.HttpContext.Request.Cookies[COOKIE_BASKET_ITEM_KEY]);
        return cartItems;
    }

    public async Task<ResultDto> Increase(BasketItemPostDto basketItemPostDto)
    {

        var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var BasketItem = _basketItemRepository.GetFiltered(i => i.ProductId == basketItemPostDto.ProductId && i.AppUserId == id).ToList().FirstOrDefault();
        if (BasketItem == null)
            throw new BasketItemNotFoundException();
        BasketItem.Count += basketItemPostDto.Count;
        _basketItemRepository.Update(BasketItem);
        await _basketItemRepository.SaveAsync();

        return new ResultDto("added");
    }

    public async Task<ResultDto> Decrease(BasketItemPostDto basketItemPostDto)
    {

        var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var BasketItem = _basketItemRepository.GetFiltered(i => i.ProductId == basketItemPostDto.ProductId && i.AppUserId == id).ToList().FirstOrDefault();
        if (BasketItem == null)
            throw new BasketItemNotFoundException();
        if(BasketItem.Count > 0)
        {
            BasketItem.Count-= basketItemPostDto.Count;
            _basketItemRepository.Update(BasketItem);
            await _basketItemRepository.SaveAsync();
        }
        if(BasketItem.Count <= 0)
        {
            _basketItemRepository.Delete(BasketItem);
            await _basketItemRepository.SaveAsync();
        }
            

        return new ResultDto("exported");
    }

    public async Task<ResultDto> BuyTheBasket(string? location)
    {
        if(!_isAuthenticated)
            throw new CannotBuyException();
        var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var basketItems =await _basketItemRepository.GetFiltered(i => i.AppUserId == userId && i.IsSold == false,"Product").ToListAsync();
        if (basketItems.Count is 0)
                throw new BasketIsEmptyException();
        OrderGetDto order =(await _orderService.CreateOrderAsync(basketItems,location)).data;
        
        
        foreach (var item in basketItems)
        {
            item.IsSold = true;
            item.StaticPrice = item.Product.Price;
            _basketItemRepository.Update(item);
            item.Product.Count -= item.Count;
            item.OrderId = order.Id;

            await _productService.UpdateProductAsync(_mapper.Map<ProductPutDto>(item.Product));
        }
        await _basketItemRepository.SaveAsync();
        return new("Successfully");
    }
}
