using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.ProductExceptions;

public class ProductNotFoundException : Exception, IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Product is not found!";
    public ProductNotFoundException():base()
    {

    }
    public ProductNotFoundException(string message):base(message)
    {
        Message = message;
    }

}
