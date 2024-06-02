using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.CommentDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
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
        _userID = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        _userManager = userManager;
        _productService = productService;
    }

    public async Task<ResultDto> CreateCommentAsync(CommentPostDto CommentPostDto)
    {
        var user =await _userManager.FindByIdAsync(_userID);
        var roles=await _userManager.GetRolesAsync(user);
        var isExist=user.BasketItems.Any(o=>o.ProductId==CommentPostDto.ProductId && o.AppUserId==_userID && o.IsSold==true);
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
        await _commentRepository.CreateAsync(comment);
        await ProductRatingUptaded(comment.ProductId);
        return new ResultDto("Comment is successfully added");
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
            await ProductRatingUptaded(comment.ProductId);
            return new("Comment is successfully deleted");
        }
        throw new RestrictedActionException("You are not allowed to delete other users' comment!");
    }

    public async Task<DataResultDto<List<CommentGetDto>>> GetAllCommentsByProductIdAsync(int productId)
    {
        var product=await _productService.GetProductByIdAsync(productId);
        var CommentDtos = _mapper.Map<List<CommentGetDto>>(product.data.Comments);
        foreach (var dto in CommentDtos)
        {
            dto.AppUserName = (await _userManager.FindByIdAsync(dto.AppUserID)).UserName;
        }


        return new(CommentDtos);
    }

    public async Task ProductRatingUptaded(int ProductId)
    {
        var comments = _commentRepository.GetFiltered(x => x.ProductId == ProductId && x.ParentId == null);
        var Ratings = new List<int>();
        foreach (var comment in comments)
        {
            Ratings.Add(comment.Rating);
        }
         var productGetDto=(await _productService.GetProductByIdAsync(ProductId)).data;
        var product=_mapper.Map<Product>(productGetDto);
        var avrg = Queryable.Average(Ratings.AsQueryable());
        product.Rating = avrg;
        var uptadedProduct=_mapper.Map<ProductRatingPutDto>(product);
        await _productService.UpdateProductRatingAsync(uptadedProduct);
    }
}
