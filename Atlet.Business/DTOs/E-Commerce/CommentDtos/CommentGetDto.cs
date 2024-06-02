using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.CommentDtos;

public class CommentGetDto:IDto
{
    public int Id { get; set; }
    public string Text { get; init; }
    public int Rating { get; init; }
    public string AppUserID { get; init; }
    public string AppUserName { get; set; }
    public string CreatedBy { get; set; }

    public int ProductId { get; init; }
    public int? ParentId { get; init; }
}
