using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.ProductExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;




    public ProductService(IProductRepository productRepository, IMapper mapper, IImageService imageService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetAllProductsAsync(string? search)
    {
        var Products =await _productRepository.GetFiltered(p=> !string.IsNullOrWhiteSpace(search) ? p.Name.Contains(search):true,"ProductCategory", "Brand","Aroma").ToListAsync();
        var query=_mapper.Map<List<ProductGetDto>>(Products);
        if (query.Count == 0)
            throw new ProductNotFoundException();
        return new DataResultDto<List<ProductGetDto>>(query);
    }

    public async Task<DataResultDto<ProductGetDto>> GetProductByIdAsync(int Id)
    {
        var product=await _productRepository.GetByIdAsync(Id);
        if (product is null)
            throw new ProductNotFoundException();

        var productDto = _mapper.Map<ProductGetDto>(product);
        return new DataResultDto<ProductGetDto>(productDto);
    }

    public async Task<ResultDto> CreateProductAsync(ProductPostDto productPostDto)
    {
        var product=_mapper.Map<Product>(productPostDto);
        await _productRepository.CreateAsync(product);
        await _imageService.CreateProductImages(product.Id, productPostDto.ProductImagePaths);
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product successfully created");
    }

    public async Task<ResultDto> UpdateProductAsync(ProductPutDto productPutDto)
    { var isExist = await _productRepository.IsExistAsync(p => p.Name == productPutDto.Name && p.Id != productPutDto.Id);
        if (isExist is true)
            throw new ProductAlreadyExistException();

        var uptadedProduct = _productRepository.GetSingleAsync(p => p.Id == productPutDto.Id).Result;
        if (uptadedProduct is null)
            throw new ProductNotFoundException();

        var product=_mapper.Map(productPutDto,uptadedProduct);
        _productRepository.Update(product);
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product successfully uptated");
    }

    public async Task<ResultDto> DeleteProductAsync(int Id)
    {
        var product =await _productRepository.GetByIdAsync(Id);
        if (product is null)
            throw new ProductNotFoundException();
        _productRepository.Delete(product);
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product is successfully deleted");

    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetFilteredProducts(ProductFilteredDtos filter)
    {


        // var products = await _productRepository.GetFiltered(p => filter.categoryId == null! ? p.ProductCategoryId == filter.categoryId :true && filter.brandId == null! ?
        // p.BrandId == filter.brandId :true && filter.aromaId == null! ? p.AromaId == filter.aromaId :true && filter.fromPrice == null! ? p.Price > filter.fromPrice :true && filter.toPrice == null! ?
        // p.Price < filter.toPrice :true && filter.fromRating == null! ? p.Rating > filter.fromRating :true && filter.toRating == null! ? p.Rating < filter.toRating :true
        //, "ProductCategory", "Aroma", "Brand").ToListAsync();

        var products =_productRepository.GetAll("ProductCategory", "Brand", "Aroma");
        if(filter.categoryId is not null)
        {
            products = products.Where(p=>p.ProductCategoryId == filter.categoryId);
        }
        if(filter.brandId is not null)
        {
            products = products.Where(p => p.BrandId == filter.brandId);
        }
        if(filter.aromaId is not null)
        {
            products=products.Where(p=>p.AromaId==filter.aromaId);
        }
        if(filter.fromPrice is not null)
        {
            products = products.Where(p => p.Price >= filter.fromPrice);
        }
        if(filter.toPrice is not null)
        {
            products=products.Where(p=>p.Price <= filter.toPrice);
        }
        if(filter.fromRating is not null)
        {
            products=products.Where(p=>p.Rating >= filter.fromRating);
        }
        if(filter.toRating is not null)
        {
            products = products.Where(p=>p.Rating <= filter.toRating);
        }
        //var products = await _productRepository.GetFiltered(p => p.ProductCategoryId == filter.categoryId && p.BrandId == filter.brandId && p.AromaId == filter.aromaId && p.Price >= filter.fromPrice &&
        //p.Price <= filter.toPrice && p.Rating >= filter.fromRating && p.Rating <= filter.toRating, "productcategory", "aroma", "brand").ToListAsync();
        if (products.ToList().Count is 0)
        {
            throw new ProductNotFoundException();
        }
        var productGetDtos=_mapper.Map<List<ProductGetDto>>(products);
        return new DataResultDto<List<ProductGetDto>>(productGetDtos);
    }

    private void createImages(string[] paths,Product product)
    {

    }
}
