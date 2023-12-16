using Atlet.Business.DTOs.E_Commerce.ProductDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class ProductAutoMapper:Profile
{
	public ProductAutoMapper()
	{
		CreateMap<Product, ProductGetDto>().ReverseMap();
		CreateMap<Product, ProductPostDto>().ReverseMap();
		CreateMap<Product, ProductPutDto>().ReverseMap();
		CreateMap<Product, ProductRatingPutDto>().ReverseMap();
		CreateMap<Product, ProductRelationDto>().ReverseMap();
		CreateMap<ProductGetDto, ProductRelationDto>().ReverseMap();
	}
}
