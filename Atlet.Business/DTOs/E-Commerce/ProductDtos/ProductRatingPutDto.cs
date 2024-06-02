using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.E_Commerce.ProductDtos;

public class ProductRatingPutDto:IDto
{
    public int Id { get; init; }
    public double Rating { get; init; }
    
}
