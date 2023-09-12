using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;
using Atlet.Business.Exceptions.E_Commerce;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class BasketItemService : IBasketItemService
{
    private readonly IBasketItemRepository _basketItemRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly bool _isAuthenticated;
    private const string COOKIE_BASKET_ITEM_KEY = "mybasketitemkey";

    public BasketItemService(IHttpContextAccessor contextAccessor, IMapper mapper, IBasketItemRepository basketItemRepository)
    {
        _contextAccessor = contextAccessor;
        _mapper = mapper;
        _basketItemRepository = basketItemRepository;
        _isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    
    public async Task<IResult> AddAsync(BasketItemPostDto dto)
    {
        var basketItem = _mapper.Map<BasketItem>(dto);
        if (_isAuthenticated)
        {
            var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ExistBasketItem=_basketItemRepository.GetFiltered(i=>i.ProductId == dto.ProductId && i.AppUserId==id).FirstOrDefault() ;
            if(ExistBasketItem is null)
                await _basketItemRepository.CreateAsync(basketItem);

            ExistBasketItem.Count += dto.Count;
            _basketItemRepository.Update(ExistBasketItem);
            await _basketItemRepository.SaveAsync();      
        
        }
        else
            await AddBasketItemToCookieAsync(basketItem);

        return new ResultDto("product successfully added");
        
    }

    public async Task<IResult> DeleteByIdAsync(int id)
    {
        var basketItem=await _basketItemRepository.GetFiltered(i=>i.ProductId==id,"Product").FirstOrDefaultAsync();
        if (basketItem is null)
            throw new BasketItemNotFoundException();
        if (_isAuthenticated)
        {
            var UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                basketItem=await _basketItemRepository.GetFiltered(i=>i.ProductId==id && i.AppUserId==UserId,"Product").FirstOrDefaultAsync();
            _basketItemRepository.Delete(basketItem);
            await _basketItemRepository.SaveAsync();
        }
        else
        {

            var basketItems=GetBasketItemsFromCookie();
            try
            {

            basketItems.Remove(basketItem);
            }
            catch (Exception)
            {

                throw new BasketItemNotFoundException();
            }
            _contextAccessor.HttpContext.Response.Cookies.Append(COOKIE_BASKET_ITEM_KEY, JsonConvert.SerializeObject(basketItems));


        }

        return new ResultDto("Product is removed");
    }

    public async Task<DataResultDto<List<BasketItemGetDto>>> GetAllAsync()
    {
        if (_isAuthenticated)
        {
            var id = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var basketItems = await _basketItemRepository.GetFiltered(i => i.AppUserId == id).ToListAsync();
            var itemDtos=_mapper.Map<List<BasketItemGetDto>>(basketItems);
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
    }
    private List<BasketItem> GetBasketItemsFromCookie()
    {
        List<BasketItem> cartItems = null;
        if (_contextAccessor.HttpContext.Request.Cookies[COOKIE_BASKET_ITEM_KEY] != null)
            cartItems = JsonConvert.DeserializeObject<List<BasketItem>>(_contextAccessor.HttpContext.Request.Cookies[COOKIE_BASKET_ITEM_KEY]);
        return cartItems;
    }

    public Task<IResult> Increase(int productId, int? count = 1)
    {

        throw new NotImplementedException();
    }

    public Task<IResult> Decrease(int productId, int? count = 1)
    {
        throw new NotImplementedException();
    }
}
