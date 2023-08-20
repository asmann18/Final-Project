using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.AromaExceptions;

public class AromaAlreadyExistException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Aroma is already exist!";
    public AromaAlreadyExistException() : base()
    {

    }
    public AromaAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
