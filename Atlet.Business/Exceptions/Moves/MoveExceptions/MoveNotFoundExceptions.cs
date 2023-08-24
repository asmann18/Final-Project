using System.Net;

namespace Atlet.Business.Exceptions.Moves.MoveExceptions;

public class MoveNotFoundExceptions:Exception
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Move is not found!";
    public MoveNotFoundExceptions() : base()
    {

    }
    public MoveNotFoundExceptions(string message) : base(message)
    {
        Message = message;
    }
}
