using System.Net;

namespace Atlet.Business.Exceptions.E_Commerce.Comment;

public class CommentNotFoundException:Exception,IBaseException
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.NotFound;
    public string Message { get; set; } = "Comment is not found!";
    public CommentNotFoundException() : base()
    {

    }
    public CommentNotFoundException(string message) : base(message)
    {
        Message = message;
    }
}
