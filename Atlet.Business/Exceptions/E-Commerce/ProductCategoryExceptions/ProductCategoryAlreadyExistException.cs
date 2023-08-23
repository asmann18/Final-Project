using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.ProductCategoryExceptions;

internal class ProductCategoryAlreadyExistException : Exception, IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "ProductCategory is already exist!";
    public ProductCategoryAlreadyExistException() : base()
    {

    }
    public ProductCategoryAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }

}
