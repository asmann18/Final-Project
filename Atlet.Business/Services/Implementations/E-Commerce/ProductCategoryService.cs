using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.ProductCategoryExceptions;
using Atlet.Business.Exceptions.E_Commerce.ProductExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper, IImageService imageService)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<ResultDto> CreateCategoryAsync(ProductCategoryPostDto productCategoryPostDto)
    {
        var isExist = await _productCategoryRepository.IsExistAsync(p => p.Name == productCategoryPostDto.Name);
        if (isExist)
            throw new ProductAlreadyExistException();
    var productCategory=_mapper.Map<ProductCategory>(productCategoryPostDto);
        await _productCategoryRepository.CreateAsync(productCategory);
        await _productCategoryRepository.SaveAsync();
        return new ResultDto(false, "ProductCategory is successfully created");
    }

    public async Task<ResultDto> DeleteCategoryAsync(int Id)
    {
        var productCategory=await _productCategoryRepository.GetByIdAsync(Id);
        if (productCategory is null)
            throw new ProductCategoryNotFoundException();
        _productCategoryRepository.Delete(productCategory);
        await _productCategoryRepository.SaveAsync();
        return new ResultDto(true,"ProductCategory successfully deleted");
    }

    public async Task<DataResultDto<List<ProductCategoryGetDto>>> GetAllCategoriesAsync(string? search)
    {
        var productCategories=await _productCategoryRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.ToUpper().Contains(search.ToUpper()) : true).ToListAsync();
        if (productCategories.Count() is 0)
            throw new ProductCategoryNotFoundException();

        var productCategoryGetDtos=_mapper.Map<List<ProductCategoryGetDto>>(productCategories);
        return new DataResultDto<List<ProductCategoryGetDto>>(productCategoryGetDtos);
    }

    public async Task<DataResultDto<List<ProductRelationDto>>> GetAllProductsInCategoryByIdAsync(int id)
    {
        var productCategory=await _productCategoryRepository.GetByIdAsync(id,"Products");
        if (productCategory is null)
            throw new ProductCategoryNotFoundException();
        var productDtos = _mapper.Map<List<ProductRelationDto>>(productCategory.Products);
        foreach (var dto in productDtos)
        {
            dto.ProductImagePaths= await _imageService.GetProductImageUrlsByIdAsync(dto.Id);
        }
        return new DataResultDto<List<ProductRelationDto>>(productDtos);

    }

    public async Task<DataResultDto<ProductCategoryGetDto>> GetCategoryByIdAsync(int Id)
    {

        var productCategory = await _productCategoryRepository.GetByIdAsync(Id);
        if (productCategory is null)
            throw new ProductCategoryNotFoundException();
        var productCategoryGetDto = _mapper.Map<ProductCategoryGetDto>(productCategory);
        return new DataResultDto<ProductCategoryGetDto>(productCategoryGetDto);
    }

    public async Task<ResultDto> UpdateCategoryAsync(ProductCategoryPutDto productCategoryPutDto)
    {
        var isExist = await _productCategoryRepository.IsExistAsync(p => p.Name == productCategoryPutDto.Name && p.Id != productCategoryPutDto.Id);
        if(isExist is true)
            throw new ProductCategoryAlreadyExistException();
        isExist = await _productCategoryRepository.IsExistAsync(p => p.Id == productCategoryPutDto.Id);
        if(isExist is false)
            throw new ProductCategoryNotFoundException();
        var productCategory = _mapper.Map<ProductCategory>(productCategoryPutDto);
        _productCategoryRepository.Update(productCategory);
        await _productCategoryRepository.SaveAsync();
        return new ResultDto(true, "Product is successfully uptaded");

    }
}
