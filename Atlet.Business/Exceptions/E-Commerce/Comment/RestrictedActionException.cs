using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.Comment;

public class RestrictedActionException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "User may comment only product bought!";
    public RestrictedActionException() : base()
    {

    }
    public RestrictedActionException(string message) : base(message)
    {
        Message = message;
    }

}
