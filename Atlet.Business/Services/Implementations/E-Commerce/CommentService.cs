using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(IMapper mapper, ICommentRepository commentRepository)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
    }

    public Task<ResultDto> CreateCommentAsync(CommentPostDto CommentPostDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResultDto> DeleteCommentAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<DataResultDto<List<CommentGetDto>>> GetAllCommentsAsync(string? search)
    {
        throw new NotImplementedException();
    }

    public Task<DataResultDto<CommentGetDto>> GetCommentByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }
}
