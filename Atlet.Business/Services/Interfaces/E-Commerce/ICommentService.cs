using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.CommentDtos;

namespace Atlet.Business.Services.Interfaces.E_Commerce;

public interface ICommentService
{

    Task<DataResultDto<List<CommentGetDto>>> GetAllCommentsByProductIdAsync(int productId);
    
    Task<ResultDto> CreateCommentAsync(CommentPostDto CommentPostDto);
    Task<ResultDto> DeleteCommentAsync(int Id);
}
