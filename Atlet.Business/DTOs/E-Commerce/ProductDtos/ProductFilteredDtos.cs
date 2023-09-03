using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public record ProductFilteredDtos(int? categoryId, int? brandId, int? aromaId, int? fromPrice, int? toPrice, int? fromRating, int? toRating):IDto;
