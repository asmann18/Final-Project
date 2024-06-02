using System.Net;

namespace Atlet.Business.Exceptions.Identity;

public class RoleNotFoundException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Move is not found!";
    public RoleNotFoundException() : base()
    {

    }
    public RoleNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
