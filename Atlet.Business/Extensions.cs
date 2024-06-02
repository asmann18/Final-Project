using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business;

public static class Extensions
{
    public static async Task<string>  SaveImage(this IFormFile file, IWebHostEnvironment webHostEnvironment)
    {
        var fileName=$"{Guid.NewGuid()}-{file.FileName}";
        var path=Path.Combine(webHostEnvironment.ContentRootPath,fileName);
        using(FileStream stream=new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return path;
    }
}
