using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Common;

public record ResultDto(bool success=true,string message="successfully"):IDto;

