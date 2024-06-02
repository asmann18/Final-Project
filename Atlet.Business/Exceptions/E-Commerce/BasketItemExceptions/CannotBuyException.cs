using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.BasketItemExceptions;

public class CannotBuyException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Sale is not possible without registration!";
    public CannotBuyException() : base()
    {

    }
    public CannotBuyException(string message) : base(message)
    {
        Message = message;
    }
}
