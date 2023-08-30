using Atlet.Business.DTOs.Blogs.BlogCategoryDtos;
using Atlet.Business.DTOs.Blogs.BlogDtos;
using Atlet.Business.DTOs.Common;
using Atlet.Business.Exceptions.Blogs.BlogCategoryExceptions;
using Atlet.Business.Services.Interfaces.Blogs;
using Atlet.Core.Entities.Blogs;
using Atlet.DataAccess.Repostories.Interfaces.Blogs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.Blogs;

public class BlogCategoryService : IBlogCategoryService
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IMapper _mapper;

    public BlogCategoryService(IMapper mapper, IBlogCategoryRepository blogCategoryRepository)
    {
        _mapper = mapper;
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<ResultDto> CreateBlogCategoryAsync(BlogCategoryPostDto blogCategoryPostDto)
    {
        var isExist=await _blogCategoryRepository.IsExistAsync(c=>c.Name==blogCategoryPostDto.Name);
        if (isExist)
            throw new BlogCategoryAlreadyExistException();
        var category=_mapper.Map<BlogCategory>(blogCategoryPostDto);
        await _blogCategoryRepository.CreateAsync(category);
        return new ResultDto(true, "Blog Category is successfully created");
    }
     
    public async Task<ResultDto> DeleteBlogCategoryAsync(int Id)
    {
        var category=await _blogCategoryRepository.GetByIdAsync(Id);
        if (category == null)
            throw new BlogCategoryNotFoundException();
        _blogCategoryRepository.Delete(category);
        await _blogCategoryRepository.SaveAsync();
        return new ResultDto(true, "BlogCategory is successfully deleted");
    }

    public async Task<DataResultDto<List<BlogCategoryGetDto>>> GetAllBlogCategorysAsync(string? search)
    {
        var categories = await _blogCategoryRepository.GetFiltered(c => !string.IsNullOrWhiteSpace(search) ? c.Name.ToLower().Contains(search.ToLower()):true,"Blogs" ).ToListAsync();
        if(categories.Count == 0)
            throw new BlogCategoryNotFoundException();
        var categoryDtos=_mapper.Map<List<BlogCategoryGetDto>>(categories);
        return new DataResultDto<List<BlogCategoryGetDto>>(categoryDtos);
    }

    public async Task<DataResultDto<List<BlogGetDto>>> GetAllBlogsByCategoryId(int id)
    {
        var category = await _blogCategoryRepository.GetByIdAsync(id, "Blogs");
        if (category == null)
            throw new BlogCategoryNotFoundException();
        var blogsDtos=_mapper.Map<List<BlogGetDto>>(category.Blogs);
        return new DataResultDto<List<BlogGetDto>>(blogsDtos);
    }

    public async Task<DataResultDto<BlogCategoryGetDto>> GetBlogCategoryByIdAsync(int Id)
    {
        var category=await _blogCategoryRepository.GetByIdAsync(Id,"Blogs");
        if (category == null) throw new BlogCategoryNotFoundException();
        var categoryDto = _mapper.Map<BlogCategoryGetDto>(category);
        return new DataResultDto<BlogCategoryGetDto>(categoryDto);
    }

    public async Task<ResultDto> UpdateBlogCategoryAsync(BlogCategoryPutDto blogCategoryPutDto)
    {
        var isExist=await _blogCategoryRepository.IsExistAsync(p=>p.Name==blogCategoryPutDto.Name && p.Id!=blogCategoryPutDto.Id);
        if (isExist)
            throw new BlogCategoryAlreadyExistException();
        isExist=await _blogCategoryRepository.IsExistAsync(c=>c.Id==blogCategoryPutDto.Id);
        if(!isExist)
            throw new BlogCategoryNotFoundException();
        var category=_mapper.Map<BlogCategory>(blogCategoryPutDto);
        _blogCategoryRepository.Update(category);
        await _blogCategoryRepository.SaveAsync();
        return new ResultDto(true,"BlogCategory is successfully uptaded");
    }
}
