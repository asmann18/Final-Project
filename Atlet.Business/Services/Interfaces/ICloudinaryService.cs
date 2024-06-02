using Microsoft.AspNetCore.Http;

namespace Atlet.Business.Services.Interfaces;

public interface ICloudinaryService
{
    Task<string> FileCreateAsync(IFormFile file);

}
