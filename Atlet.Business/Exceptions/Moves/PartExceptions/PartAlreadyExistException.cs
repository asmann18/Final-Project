using System.Net;

namespace Atlet.Business.Exceptions.Moves.PartExceptions;

public class PartAlreadyExistException:Exception
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Part is already exist!";
    public PartAlreadyExistException() : base()
    {

    }
    public PartAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
