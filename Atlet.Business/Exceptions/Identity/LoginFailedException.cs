using System.Net;

namespace Atlet.Business.Exceptions.Identity;

public class LoginFailedException : Exception,IBaseException
{
    public LoginFailedException(string message) : base(message)
    {
        Message = message;
    }
    public LoginFailedException() 
    {
        
    }

    public int StatusCode { get; set; } = (int)HttpStatusCode.Unauthorized;
    public string Message { get; set; } = "Invalid username or password";
}
