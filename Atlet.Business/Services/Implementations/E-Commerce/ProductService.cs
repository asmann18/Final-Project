using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.Product;
using Atlet.Business.Exceptions.E_Commerce.ProductExceptions;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;


    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;

    }

    public async Task<DataResultDto<List<ProductGetDto>>> GetAllProductsAsync(string? search)
    {
        var Products =await _productRepository.GetFiltered(p=> !string.IsNullOrWhiteSpace(search) ? p.Name.Contains(search):true, "ProductCategory","Brand","Aroma","ProductImage","Comment").ToListAsync();
        var query=_mapper.Map<List<ProductGetDto>>(Products);
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
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product successfully created");
    }

    public async Task<ResultDto> UpdateProductAsync(ProductPutDto productPutDto)
    {
        var product=_mapper.Map<Product>(productPutDto);
        _productRepository.Update(product);
        await _productRepository.SaveAsync();
        return new ResultDto(true, "Product successfully uptated");
    }

    public Task<ResultDto> DeleteProductAsync(int Id)
    {
        throw new NotImplementedException();
    }

}
