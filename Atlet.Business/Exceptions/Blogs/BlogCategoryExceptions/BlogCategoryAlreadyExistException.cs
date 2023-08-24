using System.Net;

namespace Atlet.Business.Exceptions.Blogs.BlogCategoryExceptions;

public class BlogCategoryAlreadyExistException:Exception
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "BlogCategory is already exist!";
    public BlogCategoryAlreadyExistException() : base()
    {

    }
    public BlogCategoryAlreadyExistException(string message) : base(message)
    {
        Message = message;
    }
}
