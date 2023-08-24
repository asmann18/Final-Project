using System.Net;

namespace Atlet.Business.Exceptions.Moves.MoveExceptions;

public class MoveAlreadyExistException:Exception
{

    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Move is already exist!";
    public MoveAlreadyExistException() : base()
    {

    }
    public MoveAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
