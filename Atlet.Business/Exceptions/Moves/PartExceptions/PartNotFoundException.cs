using System.Net;

namespace Atlet.Business.Exceptions.Moves.PartExceptions;

public class PartNotFoundException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Part is not found!";
    public PartNotFoundException() : base()
    {

    }
    public PartNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
