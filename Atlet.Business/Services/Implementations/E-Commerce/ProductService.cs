using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.ProductExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        var Products =await _productRepository.GetFiltered(p=> !string.IsNullOrWhiteSpace(search) ? p.Name.Contains(search):true, "ProductCategory", "Brand", "Aroma", "Comments", "ProductImages").OrderByDescending(x=>x.Id).ToListAsync();
        var query=_mapper.Map<List<ProductGetDto>>(Products);
        if (query.Count == 0)
            throw new ProductNotFoundException();
        foreach (var item in query)
        {
            item.ProductImagePaths =await _imageService.GetProductImageUrlsByIdAsync(item.Id);
        }
        return new DataResultDto<List<ProductGetDto>>(query);
    }

    public async Task<DataResultDto<ProductGetDto>> GetProductByIdAsync(int Id)
    {
        var product=await _productRepository.GetByIdAsync(Id, "ProductCategory", "Brand", "Aroma","Comments", "ProductImages");
        if (product is null)
            throw new ProductNotFoundException();
        var productDto = _mapper.Map<ProductGetDto>(product);
        productDto.ProductImagePaths = await _imageService.GetProductImageUrlsByIdAsync(Id);
        return new DataResultDto<ProductGetDto>(productDto);
    }

    public async Task<ResultDto> CreateProductAsync(ProductPostDto productPostDto)
    {
        var product=_mapper.Map<Product>(productPostDto);
        await _productRepository.CreateAsync(product);
        await _imageService.CreateProductImages(product.Id, productPostDto.ProductImagesF);
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
        if(productPutDto.ProductImagesF is not null)
        {
            await _imageService.UpdateProductImages(productPutDto.Id, productPutDto.ProductImagesF);
        }
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
        await _imageService.DeleteProductImages(product.Id);
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product is successfully deleted");

    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetFilteredProducts(ProductFilteredDtos filter)
    {


        // var products = await _productRepository.GetFiltered(p => filter.categoryId == null! ? p.ProductCategoryId == filter.categoryId :true && filter.brandId == null! ?
        // p.BrandId == filter.brandId :true && filter.aromaId == null! ? p.AromaId == filter.aromaId :true && filter.fromPrice == null! ? p.Price > filter.fromPrice :true && filter.toPrice == null! ?
        // p.Price < filter.toPrice :true && filter.fromRating == null! ? p.Rating > filter.fromRating :true && filter.toRating == null! ? p.Rating < filter.toRating :true
        //, "ProductCategory", "Aroma", "Brand").ToListAsync();

        var products =_productRepository.GetAll("ProductCategory", "Brand", "Aroma", "Comments", "ProductImages");
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
        foreach (var item in productGetDtos)
        {
            item.ProductImagePaths = await _imageService.GetProductImageUrlsByIdAsync(item.Id);
        }
        return new DataResultDto<List<ProductGetDto>>(productGetDtos);
    }

    public async Task<ResultDto> UpdateProductRatingAsync(ProductRatingPutDto productRatingPutDto)
    {

        var uptadedProduct = _productRepository.GetSingleAsync(p => p.Id == productRatingPutDto.Id).Result;
        if (uptadedProduct is null)
            throw new ProductNotFoundException();

        var product = _mapper.Map(productRatingPutDto, uptadedProduct);
        _productRepository.Update(product);
        await _productRepository.SaveAsync();
        return new("Product rating successfully uptaded");
    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetDiscountProducts()
    {
        var products = _productRepository.GetAll("ProductCategory", "Brand", "Aroma", "Comments", "ProductImages").OrderByDescending(p => p.Discount);
        List<ProductGetDto> productDtos=new List<ProductGetDto>();
        if (products.Count() > 10)
        {
            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x=>x.Discount).Take(10).ToListAsync());
        }
        else
        {

            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x => x.Discount).ToListAsync());
        }
        foreach (var item in productDtos)
        {
            item.ProductImagePaths = await _imageService.GetProductImageUrlsByIdAsync(item.Id);
        }
        return new DataResultDto<List<ProductGetDto>>(productDtos, true);
    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetPopularProducts()
    {
        var products = _productRepository.GetAll("ProductCategory", "Brand", "Aroma", "Comments", "ProductImages").OrderByDescending(p => p.SalesCount);
        List<ProductGetDto> productDtos = new List<ProductGetDto>();
        if (products.Count() > 10)
        {
            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x=>x.Rating).Take(10).ToListAsync());
        }
        else
        {

            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x => x.Rating).ToListAsync());
        }
        foreach (var item in productDtos)
        {
            item.ProductImagePaths = await _imageService.GetProductImageUrlsByIdAsync(item.Id);
        }
        return new DataResultDto<List<ProductGetDto>>(productDtos, true);

    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetBestSellerProducts()
    {
        var products = _productRepository.GetAll("ProductCategory", "Brand", "Aroma", "Comments", "ProductImages").OrderByDescending(p => p.Discount);
        List<ProductGetDto> productDtos = new List<ProductGetDto>();
        if (products.Count() > 10)
        {
            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x => x.SalesCount).Take(10).ToListAsync());
        }
        else
        {

            productDtos = _mapper.Map<List<ProductGetDto>>(await products.OrderByDescending(x => x.SalesCount).ToListAsync());
        }
        foreach (var item in productDtos)
        {
            item.ProductImagePaths = await _imageService.GetProductImageUrlsByIdAsync(item.Id);
        }
        return new DataResultDto<List<ProductGetDto>>(productDtos, true);
    }
}
