using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.BrandExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public BrandService(IBrandRepository brandRepository, IMapper mapper, IImageService imageService)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<ResultDto> CreateBrandAsync(BrandPostDto brandPostDto)
    {
        var isExist = await _brandRepository.IsExistAsync(b => b.Name == brandPostDto.Name);
        if (isExist)
            throw new BrandAlreadyExistException();
        var brand = _mapper.Map<Brand>(brandPostDto);
        brand.ImageId=await _imageService.CreateImage(brandPostDto.ImageF);
        await _brandRepository.CreateAsync(brand);
        return new ResultDto(true, "Brand is successfully created");
    }

    public async Task<ResultDto> DeleteBrandAsync(int Id)
    {
        var brand = await _brandRepository.GetByIdAsync(Id);
        if (brand is null)
            throw new BrandNotFoundException();

        _brandRepository.Delete(brand);
        await _imageService.DeleteImage(brand.ImageId);
        await _brandRepository.SaveAsync();
        return new ResultDto(true, "Brand is successfully deleted");
    }

    public async Task<DataResultDto<List<BrandGetDto>>> GetAllBrandsAsync(string? search)
    {
        var brands = await _brandRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.ToLower().Contains(search.ToLower()) : true, "Products","Image").ToListAsync();
        var brandsDto=_mapper.Map<List<BrandGetDto>>(brands);
     
        return new DataResultDto<List<BrandGetDto>>(brandsDto);


    }

    public async Task<DataResultDto<List<ProductRelationDto>>> GetAllProductsInBrandByBrandIdAsync(int Id)
    {

        var brand=await GetBrandByIdAsync(Id);
        var products = _mapper.Map<List<ProductRelationDto>>(brand.data.Products);
        return new DataResultDto<List<ProductRelationDto>>(products);
    }

    public async Task<DataResultDto<BrandGetDto>> GetBrandByIdAsync(int Id)
    {
        Brand brand = await _brandRepository.GetByIdAsync(Id, "Products","Image");
        if (brand is null)
            throw new BrandNotFoundException();
        var brandDto = _mapper.Map<BrandGetDto>(brand);
        return new DataResultDto<BrandGetDto>(brandDto);

    }

    public async Task<ResultDto> UpdateBrandAsync(BrandPutDto brandPutDto)
    {
        var isExist=await _brandRepository.IsExistAsync(b=>b.Name==brandPutDto.Name &&  b.Id!=brandPutDto.Id);
        if (isExist)
            throw new BrandAlreadyExistException();
        isExist = await _brandRepository.IsExistAsync(b => b.Id == brandPutDto.Id);
        if (!isExist)
            throw new BrandNotFoundException();
        var existingBrand = await _brandRepository.GetByIdAsync(brandPutDto.Id);

        if (existingBrand == null)
            throw new BrandNotFoundException();

            var brand = _mapper.Map(brandPutDto,existingBrand);
        if(brandPutDto.ImageF is not null)
        {
            brand.ImageId=await _imageService.UpdateImage(brandPutDto.Id, brandPutDto.ImageF);

        }
        _brandRepository.Update(brand);
        await _brandRepository.SaveAsync();
            return new ResultDto(true,"Product successfully uptaded");
    }
}
