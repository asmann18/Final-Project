using System.Net;

namespace Atlet.Business.Exceptions.Identity;

public class UserNotFoundException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Move is not found!";
    public UserNotFoundException() : base()
    {

    }
    public UserNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
