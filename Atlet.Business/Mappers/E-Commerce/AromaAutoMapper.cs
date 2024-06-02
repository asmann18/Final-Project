using Atlet.Business.DTOs.E_Commerce.AromaDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class AromaAutoMapper:Profile
{
    public AromaAutoMapper()
    {
        CreateMap<Aroma, AromaGetDto>().ReverseMap();
        CreateMap<Aroma, AromaPostDto>().ReverseMap();
        CreateMap<Aroma, AromaPutDto>().ReverseMap();
        CreateMap<Aroma, AromaRelationDto>().ReverseMap();
    }
}
