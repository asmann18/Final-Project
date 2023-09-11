using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce;

public class BasketItemNotFoundException:Exception,IBaseException
{


    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Brand is not found!";
    public BasketItemNotFoundException() : base()
    {

    }
    public BasketItemNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
