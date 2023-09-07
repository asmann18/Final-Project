using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.Moves.MoveDtos;
using Atlet.Business.DTOs.Moves.PartDtos;
using Atlet.Business.Exceptions.Moves.PartExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.Moves;
using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Repostories.Interfaces.Moves;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.Moves;

public class PartService : IPartService
{
    private readonly IPartRepository _partRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public PartService(IMapper mapper, IPartRepository partRepository, IImageService imageService)
    {
        _mapper = mapper;
        _partRepository = partRepository;
        _imageService = imageService;
    }

    public async Task<ResultDto> CreatePartAsync(PartPostDto partPostDto)
    {
        var isExist=await _partRepository.IsExistAsync(p=>p.Name==partPostDto.Name);
        if (isExist)
            throw new PartAlreadyExistException();
        var part = _mapper.Map<Part>(partPostDto);
        part.ImageId=await _imageService.CreateImage(partPostDto.ImagePath);
        await _partRepository.CreateAsync(part);
        return new ResultDto(true, "Part is successfully created");
    }

    public async Task<ResultDto> DeletePartAsync(int Id)
    {
        var part=await _partRepository.GetByIdAsync(Id);
        if (part is null)
            throw new PartNotFoundException();
        _partRepository.Delete(part);
        await _imageService.DeleteImage(part.ImageId);
        await _partRepository.SaveAsync();
        return new ResultDto(true, "Part is successfully deleted");
    }

    public async Task<DataResultDto<List<MoveGetDto>>> GetAllMovesByPartId(int id)
    {
        var part = await _partRepository.GetByIdAsync(id,"Moves");
        if (part is null)
            throw new PartNotFoundException();
        var moveDtos=_mapper.Map<List<MoveGetDto>>(part.Moves);
        return new DataResultDto<List<MoveGetDto>>(moveDtos);
    }

    public async Task<DataResultDto<List<PartGetDto>>> GetAllPartsAsync(string? search)
    {
        var parts =await _partRepository.GetFiltered(p => !string.IsNullOrWhiteSpace(search) ? p.Name.ToLower().Contains(search.ToLower()) : true,"Moves","Image").ToListAsync();
        if(parts.Count == 0)
            throw new PartNotFoundException();
        var partDtos=_mapper.Map<List<PartGetDto>>(parts);
        return new DataResultDto<List<PartGetDto>>(partDtos);
    }

    public async Task<DataResultDto<PartGetDto>> GetPartByIdAsync(int Id)
    {
        var part = await _partRepository.GetByIdAsync(Id, "Moves","Image");
        if (part is null)
            throw new PartNotFoundException();
        var partDto=_mapper.Map<PartGetDto>(part);
        return new DataResultDto<PartGetDto>(partDto);
    }

    public async Task<ResultDto> UpdatePartAsync(PartPutDto partPutDto)
    {
        var isExist=await _partRepository.IsExistAsync(p=> p.Name==partPutDto.Name && p.Id!=partPutDto.Id);
        if (isExist)
            throw new PartAlreadyExistException();
        isExist=await _partRepository.IsExistAsync(p=>p.Id==partPutDto.Id);
        if (!isExist)
            throw new PartNotFoundException();
        var part=_mapper.Map<Part>(partPutDto);
        part.ImageId = await _imageService.UpdateImage(part.ImageId, partPutDto.ImagePath);
        _partRepository.Update(part);
        await _partRepository.SaveAsync();
        return new ResultDto(true,"Part is successfully uptaded");
    }
}
