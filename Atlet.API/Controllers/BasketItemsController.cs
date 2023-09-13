using Atlet.Business.DTOs.E_Commerce.BasketItemDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Business.Services.Interfaces.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BasketItemsController : ControllerBase
{
    private readonly IBasketItemService _basketItemService;


    public BasketItemsController(IBasketItemService basketItemService)
    {
        _basketItemService = basketItemService;
       


    }
    [HttpPost("[action]")]
    public async Task<IActionResult> AddToBasket([FromBody]BasketItemPostDto basketItemPostDto)
    {

        return Ok(await _basketItemService.AddAsync(basketItemPostDto));
    }
    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteToBasket([FromRoute]int Id)
    {
        return Ok(await _basketItemService.DeleteByIdAsync(Id));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetBasket()
    {
        return Ok(await _basketItemService.GetAllAsync());
    }

    [HttpGet("[action]")]
    [Authorize]
    public async Task<IActionResult> BuyTheBasket()
    {
        return Ok(await _basketItemService.BuyTheBasket());
    }
    
}
