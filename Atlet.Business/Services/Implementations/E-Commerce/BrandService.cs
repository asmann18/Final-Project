using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Business.Exceptions.E_Commerce.BrandExceptions;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Implementations.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    public BrandService(IBrandRepository brandRepository,IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateBrandAsync(BrandPostDto brandPostDto)
    {
        var isExist = await _brandRepository.IsExistAsync(b => b.Name == brandPostDto.Name);
        if (isExist)
            throw new BrandAlreadyExistException();
        var brand = _mapper.Map<Brand>(brandPostDto);
        return new ResultDto(true, "Brand is successfully created");
    }

    public async Task<ResultDto> DeleteBrandAsync(int Id)
    {
        var brand = await _brandRepository.GetByIdAsync(Id);
        if (brand is null)
            throw new BrandNotFoundException();

        _brandRepository.Delete(brand);
        await _brandRepository.SaveAsync();
        return new ResultDto(true, "Brand is successfully deleted");
    }

    public async Task<DataResultDto<List<BrandGetDto>>> GetAllBrandsAsync(string? search)
    {
        var brands = await _brandRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.ToLower().Contains(search.ToLower()) : true, "Product").ToListAsync();
        var brandsDto=_mapper.Map<List<BrandGetDto>>(brands);
        return new DataResultDto<List<BrandGetDto>>(brandsDto);


    }

    public async Task<DataResultDto<BrandGetDto>> GetBrandByIdAsync(int Id)
    {
        var brand = await _brandRepository.GetByIdAsync(Id, "Product");
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

        var brand = _mapper.Map<Brand>(brandPutDto);
        _brandRepository.Update(brand);
        await _brandRepository.SaveAsync();
            return new ResultDto(true,"Product successfully uptaded");
    }
}
