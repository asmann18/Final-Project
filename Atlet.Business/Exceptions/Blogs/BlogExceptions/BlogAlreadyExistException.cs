using System.Net;

namespace Atlet.Business.Exceptions.Blogs.BlogExceptions;

public class BlogAlreadyExistException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Blog is already exist!";
    public BlogAlreadyExistException() : base()
    {

    }
    public BlogAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
