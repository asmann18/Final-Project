using Atlet.Business.DTOs.Common;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface IBasketItemService
{
    Task<ResultDto> AddToBasket(int ProductId,int? count);
    Task<ResultDto> RemoveToBasket(int ProductId);
}
