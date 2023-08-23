using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.BrandExceptions;

internal class BrandNotFoundException:Exception,IBaseException
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Brand is not found!";
    public BrandNotFoundException() : base()
    {

    }
    public BrandNotFoundException(string message) : base(message)
    {
        Message = message;
    }

}
