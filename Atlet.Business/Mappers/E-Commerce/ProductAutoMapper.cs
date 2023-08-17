using Atlet.Business.DTOs.E_Commerce.Product;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

internal class ProductAutoMapper:Profile
{
	public ProductAutoMapper()
	{
		CreateMap<Product, ProductGetDto>().ReverseMap();
		CreateMap<Product, ProductPostDto>().ReverseMap();
		CreateMap<Product, ProductPutDto>().ReverseMap();
		CreateMap<Product, ProductDeleteDto>().ReverseMap();
	}
}
