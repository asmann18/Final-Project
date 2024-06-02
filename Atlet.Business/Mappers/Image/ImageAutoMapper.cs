using Atlet.Business.DTOs.ImageDtos;
using Atlet.Core.Entities;
using AutoMapper;

namespace Atlet.Business.Mappers.Images;

public class ImageAutoMapper:Profile
{
    public ImageAutoMapper()
    {
        CreateMap<Image, ImageGetDto>().ReverseMap();   
    }
}
