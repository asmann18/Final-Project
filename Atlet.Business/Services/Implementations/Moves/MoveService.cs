using Atlet.Business.DTOs.Abstract;
using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Business.DTOs.Moves.MoveDtos;
using Atlet.Business.Exceptions.Moves.MoveExceptions;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.Moves;
using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using Atlet.DataAccess.Repostories.Interfaces.Moves;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Atlet.Business.Services.Implementations.Moves;

public class MoveService : IMoveService
{
    private readonly IMoveRepository _moveRepository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public MoveService(IMapper mapper, IMoveRepository moveRepository, IImageService imageService)
    {
        _mapper = mapper;
        _moveRepository = moveRepository;
        _imageService = imageService;
    }

    public async Task<ResultDto> CreateMoveAsync(MovePostDto movePostDto)
    {
        var isExist = await _moveRepository.IsExistAsync(m => m.Name == movePostDto.Name);
        if (isExist)
            throw new MoveAlreadyExistException();
        var move = _mapper.Map<Move>(movePostDto);
        await _moveRepository.CreateAsync(move);
        await _imageService.CreateMoveImages(move.Id, movePostDto.MoveImagesF);
        return new ResultDto(true, "Move is successfully created");
    }

    public async Task<ResultDto> DeleteMoveAsync(int Id)
    {
        var move = await _moveRepository.GetByIdAsync(Id,"Part");
        if (move is null)
            throw new MoveNotFoundExceptions();
        _moveRepository.Delete(move);
        await _imageService.DeleteMoveImages(move.Id);
        await _moveRepository.SaveAsync();
        return new ResultDto(true, "Move is successfully deleted");
    }

    public async Task<DataResultDto<List<MoveGetDto>>> GetAllMovesAsync(string? search)
    {
        var moves = await _moveRepository.GetFiltered(m => !string.IsNullOrWhiteSpace(search) ? m.Name.ToLower().Contains(search.ToLower()) : true, "Part").ToListAsync();
        if (moves.Count == 0)
            throw new MoveNotFoundExceptions();
        var moveDtos = _mapper.Map<List<MoveGetDto>>(moves);

        foreach (var dto in moveDtos)
        {
            dto.MoveImagePaths = await _imageService.GetMoveImageUrlsByIdasync(dto.Id);
        }
        return new DataResultDto<List<MoveGetDto>>(moveDtos);
    }



    public async Task<DataResultDto<MoveGetDto>> GetMoveByIdAsync(int Id)
    {
        var move = await _moveRepository.GetByIdAsync(Id,"Part");
        if (move is null)
            throw new MoveNotFoundExceptions();
        var moveDto = _mapper.Map<MoveGetDto>(move);
        moveDto.MoveImagePaths = await _imageService.GetMoveImageUrlsByIdasync(moveDto.Id);
        return new DataResultDto<MoveGetDto>(moveDto);
    }

    public async Task<ResultDto> UpdateMoveAsync(MovePutDto movePutDto)
    {
        var isExist = await _moveRepository.IsExistAsync(m => m.Name == movePutDto.Name && m.Id != movePutDto.Id);
        if (isExist)
            throw new MoveAlreadyExistException();
        isExist = await _moveRepository.IsExistAsync(m => m.Id == movePutDto.Id);
        if (!isExist)
            throw new MoveNotFoundExceptions();
        if(movePutDto.MoveImagesF is not null)
        {
           await _imageService.UpdateMoveImages(movePutDto.Id,movePutDto.MoveImagesF);
        }
        var existMove = await _moveRepository.GetByIdAsync(movePutDto.Id,"Part");
        var move = _mapper.Map(movePutDto,existMove);
        _moveRepository.Update(move);
        await _moveRepository.SaveAsync();
        return new ResultDto(true, "Move is successfully uptated");
    }
}
