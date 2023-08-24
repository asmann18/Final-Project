using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.CommentDtos;

public class CommentPostDto:IDto
{
    public string Text { get; init; }
    public int Rating { get; init; }
    public int ProductId { get; init; }
    public int? ParentId { get; init; }
    public int UserId { get; set; }
}
