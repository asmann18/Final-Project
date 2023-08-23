using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.BrandExceptions;

public class BrandAlreadyExistException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Brand is already exist!";
    public BrandAlreadyExistException() : base()
    {

    }
    public BrandAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
