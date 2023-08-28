using Atlet.Business.DTOs.Moves.PartDtos;
using Atlet.Core.Entities.Moves;
using AutoMapper;

namespace Atlet.Business.Mappers.Moves;

public class PartAutoMapper:Profile
{
    public PartAutoMapper()
    {

        CreateMap<Part, PartGetDto>().ReverseMap();
        CreateMap<Part, PartPostDto>().ReverseMap();
        CreateMap<Part, PartPutDto>().ReverseMap();
    }
}
