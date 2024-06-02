using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.BasketItemExceptions;

public class BasketIsEmptyException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Basket is empty";
    public BasketIsEmptyException() : base()
    {

    }
    public BasketIsEmptyException(string message) : base(message)
    {
        Message = message;
    }
}
