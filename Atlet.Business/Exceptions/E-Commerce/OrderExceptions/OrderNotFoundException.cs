using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.OrderExceptions;

public class OrderNotFoundException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Order is not found!";
    public OrderNotFoundException() : base()
    {

    }
    public OrderNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
