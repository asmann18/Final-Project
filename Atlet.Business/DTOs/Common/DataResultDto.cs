using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.Common;

public record DataResultDto<T> (T data=default,bool success=true,string message="Successfully",byte statusCode=200):IDto;
