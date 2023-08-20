using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.ProductCategoryExceptions;

public class ProductCategoryNotFoundException:Exception,IBaseException
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "ProductCategory is not found!";
    public ProductCategoryNotFoundException() : base()
    {

    }
    public ProductCategoryNotFoundException(string message) : base(message)
    {
        Message = message;
    }

}
