using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.CommentDtos;

public class CommentRelationDto:IDto
{
    public int Id { get; set; }
    public string Text { get; init; }
    public int Rating { get; init; }
    public string AppUserID { get; init; }
    public int ProductId { get; init; }
    public int? ParentId { get; init; }
}
