using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.ProductCategoryExceptions;
using Atlet.Business.Exceptions.E_Commerce.ProductExceptions;
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
    private readonly IProductService _productService;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository,IMapper mapper,IProductService productService)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
        _productService = productService;
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
        var productCategories=await _productCategoryRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.ToUpper().Contains(search.ToUpper()) : true,"Product").ToListAsync();
        if (productCategories.Count() is 0)
            throw new ProductCategoryNotFoundException();

        var productCategoryGetDtos=_mapper.Map<List<ProductCategoryGetDto>>(productCategories);
        return new DataResultDto<List<ProductCategoryGetDto>>(productCategoryGetDtos);
    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetAllProductsInCategoryByIdAsync(int id)
    {
        var productCategory=await _productCategoryRepository.GetByIdAsync(id);
        if (productCategory is null)
            throw new ProductCategoryNotFoundException();
        var productGetDtos = _mapper.Map<List<ProductGetDto>>(productCategory.Products);
        return new DataResultDto<List<ProductGetDto>>(productGetDtos);

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
