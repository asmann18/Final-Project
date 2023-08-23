using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.AromaExceptions;
public class AromaNotFoundException:Exception,IBaseException
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Aroma is not found!";
    public AromaNotFoundException() : base()
    {

    }
    public AromaNotFoundException(string message) : base(message)
    {
        Message = message;
    }

}
