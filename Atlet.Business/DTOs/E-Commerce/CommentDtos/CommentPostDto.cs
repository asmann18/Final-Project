using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.CommentDtos;

public class CommentPostDto:IDto
{
    public string Text { get; init; }
    public int Rating { get; init; }
    public int ProductId { get; init; }
    public Product Product { get; init; }
    public int? ParentId { get; init; }
    public Comment? Parent { get; init; }
}
