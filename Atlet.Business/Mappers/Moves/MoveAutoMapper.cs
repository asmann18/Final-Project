using Atlet.Business.DTOs.Moves.MoveDtos;
using Atlet.Core.Entities.Moves;
using AutoMapper;

namespace Atlet.Business.Mappers.Moves;

public class MoveAutoMapper:Profile
{
    public MoveAutoMapper()
    {
        
        CreateMap<Move, MoveGetDto>().ReverseMap();
        CreateMap<Move, MovePostDto>().ReverseMap();
        CreateMap<Move, MovePutDto>().ReverseMap();
        CreateMap<Move, MoveRelationDto>().ReverseMap();


    }
}
