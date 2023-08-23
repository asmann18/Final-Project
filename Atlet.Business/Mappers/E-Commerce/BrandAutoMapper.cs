using Atlet.Business.DTOs.E_Commerce.BrandDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class BrandAutoMapper:Profile
{
	public BrandAutoMapper()
	{
		CreateMap<Brand,BrandGetDto>().ReverseMap();
		CreateMap<Brand,BrandPostDto>().ReverseMap();
		CreateMap<Brand,BrandPutDto>().ReverseMap();
		CreateMap<Brand,BrandDeleteDto>().ReverseMap();
	}
}
