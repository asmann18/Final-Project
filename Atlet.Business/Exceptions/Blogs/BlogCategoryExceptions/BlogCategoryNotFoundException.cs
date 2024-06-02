using System.Net;

namespace Atlet.Business.Exceptions.Blogs.BlogCategoryExceptions;

public class BlogCategoryNotFoundException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "BlogCategory is not found!";
    public BlogCategoryNotFoundException() : base()
    {

    }
    public BlogCategoryNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
