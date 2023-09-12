using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using Atlet.Business.Exceptions.E_Commerce.Comment;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Identity;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly string _userID;
    private readonly UserManager<AppUser> _userManager;
    private readonly IProductService _productService;

    public CommentService(IMapper mapper, ICommentRepository commentRepository, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager, IProductService productService)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
        _contextAccessor = contextAccessor;
        _userID = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        _userManager = userManager;
        _productService = productService;
    }

    public async Task<ResultDto> CreateCommentAsync(CommentPostDto CommentPostDto)
    {
        var user =await _userManager.FindByIdAsync(_userID);
        var roles=await _userManager.GetRolesAsync(user);
        var isExist=user.OrderItems.Any(o=>o.ProductId==CommentPostDto.ProductId && o.AppUserId==_userID);
        if (!isExist)
        {
            if (roles.FirstOrDefault() != "Admin" && roles.FirstOrDefault() != "Moderator")
                throw new RestrictedActionException();
        }
        if(CommentPostDto.ParentId is not null)
        {
            if (roles.FirstOrDefault() != "Admin" && roles.FirstOrDefault() != "Moderator")
                throw new RestrictedActionException("Only Admin and Member have a right to reply!");
        }

        var comment = _mapper.Map<Comment>(CommentPostDto);
        _commentRepository.CreateAsync(comment);
        return new("Comment is successfully added");
    }

    public async Task<ResultDto> DeleteCommentAsync(int Id)
    {
       var comment=await _commentRepository.GetByIdAsync(Id);
        if(comment is null)
           throw new CommentNotFoundException();

        var user = await _userManager.FindByIdAsync(_userID);
        var roles = await _userManager.GetRolesAsync(user);

        if (comment.AppUserID == _userID || roles.FirstOrDefault() =="Admin" || roles.FirstOrDefault()=="Member")
        {
            _commentRepository.Delete(comment);
            await _commentRepository.SaveAsync();
            return new("Comment is successfully deleted");
        }
        throw new RestrictedActionException("You are not allowed to delete other users' comment!");
    }

    public async Task<DataResultDto<List<CommentGetDto>>> GetAllCommentsByProductIdAsync(int productId)
    {
        var product=await _productService.GetProductByIdAsync(productId);
        var CommentDtos = _mapper.Map<List<CommentGetDto>>(product.data.Comments);
        return new(CommentDtos);
    }
}
