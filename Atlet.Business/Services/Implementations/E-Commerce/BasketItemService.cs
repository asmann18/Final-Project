using Atlet.Business.DTOs.Common;
using Atlet.Business.Services.Interfaces.E_Commerce;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class BasketItemService : IBasketItemService
{
    public Task<ResultDto> AddToBasket(int ProductId, int? count)
    {

        throw new NotImplementedException();
    }

    public Task<ResultDto> RemoveToBasket(int ProductId)
    {
        throw new NotImplementedException();
    }
}
