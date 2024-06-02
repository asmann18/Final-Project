using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.CommentDtos;

public class CommentDeleteDto:IDto
{
    public int Id { get; init; }
    public string Text { get; init; }
    public int Rating { get; init; }
    public int ProductId { get; init; }
    public int? ParentId { get; init; }
    public int UserId { get; set; }
}
