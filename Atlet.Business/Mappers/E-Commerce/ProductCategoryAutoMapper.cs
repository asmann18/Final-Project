using Atlet.Business.DTOs.E_Commerce.ProductCategoryDtos;
using Atlet.Core.Entities.E_Commerce;
using AutoMapper;

namespace Atlet.Business.Mappers.E_Commerce;

public class ProductCategoryAutoMapper:Profile
{
	public ProductCategoryAutoMapper()
	{
		CreateMap<ProductCategory, ProductCategoryGetDto>().ReverseMap();
		CreateMap<ProductCategory, ProductCategoryPostDto>().ReverseMap();
		CreateMap<ProductCategory, ProductCategoryPutDto>().ReverseMap();
		CreateMap<ProductCategory, ProductCategoryRelationDto>().ReverseMap();
	}
}
