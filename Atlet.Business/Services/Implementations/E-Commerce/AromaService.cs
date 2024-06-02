using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.Exceptions.E_Commerce.AromaExceptions;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.DataAccess.Repostories.Interfaces.E_Commerce;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.E_Commerce;

public class AromaService : IAromaService
{
    private readonly IAromaRepository _aromaRepository;
    private readonly IMapper _mapper;

    public AromaService(IAromaRepository aromaRepository,IMapper mapper)
    {
        _aromaRepository = aromaRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> CreateAromaAsync(AromaPostDto AromaPostDto)
    {
        var isExits=await _aromaRepository.IsExistAsync(a => a.Name == AromaPostDto.Name);
        if (isExits)
            throw new AromaAlreadyExistException();
        var aroma = _mapper.Map<Aroma>(AromaPostDto);
        await _aromaRepository.CreateAsync(aroma);
        return new ResultDto(true, "Aroma successfully created");
    }

    public async Task<ResultDto> DeleteAromaAsync(int Id)
    {
        var aroma = await _aromaRepository.GetByIdAsync(Id);
        if(aroma is null)
            throw new AromaNotFoundException();
        
        _aromaRepository.Delete(aroma);
        await _aromaRepository.SaveAsync();
        return new ResultDto(true, "Aroma successfully deleted");
    }

    public async Task<DataResultDto<List<AromaGetDto>>> GetAllAromasAsync(string? search)
    {
        var aromas = await _aromaRepository.GetFiltered(a => !string.IsNullOrWhiteSpace(search) ? a.Name.ToLower().Contains(search.ToLower()) : true, "Products").ToListAsync();
        if (aromas.Count == 0)
            throw new AromaNotFoundException();
        var aromaDtos = _mapper.Map<List<AromaGetDto>>(aromas);
        return new DataResultDto<List<AromaGetDto>>(aromaDtos);
    }

    public async Task<DataResultDto<List<ProductRelationDto>>> GetAllProductsAsync(int Id)
    {
        var aroma=await GetAromaByIdAsync(Id);
        var products=_mapper.Map<List<ProductRelationDto>>(aroma.data.Products);
        return new DataResultDto<List<ProductRelationDto>> (products);
    }

    public async Task<DataResultDto<AromaGetDto>> GetAromaByIdAsync(int Id)
    {
        var aroma = await _aromaRepository.GetByIdAsync(Id, "Products");
        if (aroma is null)
            throw new AromaNotFoundException();
        var aromaDto = _mapper.Map<AromaGetDto>(aroma);
        return new DataResultDto<AromaGetDto>(aromaDto);
    }

    public async Task<ResultDto> UpdateAromaAsync(AromaPutDto AromaPutDto)
    {
        var isExist = await _aromaRepository.IsExistAsync(a => a.Name == AromaPutDto.Name && a.Id != AromaPutDto.Id);
        if (isExist)
            throw new AromaAlreadyExistException();

        isExist = await _aromaRepository.IsExistAsync(i => i.Id == AromaPutDto.Id);
        if (!isExist)
            throw new AromaNotFoundException();

        var aroma = _mapper.Map<Aroma>(AromaPutDto);
        _aromaRepository.Update(aroma);
        await _aromaRepository.SaveAsync();
        return new ResultDto(true,"Aroma is successfully uptaded");
    }
}
