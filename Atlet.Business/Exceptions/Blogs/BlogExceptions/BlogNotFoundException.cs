using System.Net;

namespace Atlet.Business.Exceptions.Blogs.BlogExceptions;

public class BlogNotFoundException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Blog is not found!";
    public BlogNotFoundException() : base()
    {

    }
    public BlogNotFoundException(string message) : base(message)
    {
        Message = message;
    }

}
