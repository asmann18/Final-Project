using Atlet.Business.DTOs.Abstract;
using Atlet.Core.Entities.E_Commerce;

namespace Atlet.Business.DTOs.E_Commerce.AromaDtos;

public class AromaGetDto:IDto
{
    
    public string Name { get; init; }
    public ICollection<Product> Products { get; init; } = new List<Product>();

}
