using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.ProductExceptions;

public class ProductAlreadyExistException : Exception, IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Product is already exist!";
    public ProductAlreadyExistException() : base()
    {

    }
    public ProductAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }

}
