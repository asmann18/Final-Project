using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.BasketItemExceptions;

public class BasketItemCannotBeDeletedException:Exception,IBaseException
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "The history of purchased products cannot be deleted!";
    public BasketItemCannotBeDeletedException() : base()
    {

    }
    public BasketItemCannotBeDeletedException(string message) : base(message)
    {
        Message = message;
    }
}
