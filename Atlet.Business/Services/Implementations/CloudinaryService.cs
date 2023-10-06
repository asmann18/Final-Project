using Atlet.Business.Services.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Atlet.Business.Services.Implementations;

public class CloudinaryService:ICloudinaryService
{
    private const string cloud_name = "dlilcwizx";
    private const string api_key = "646523828955691";
    private const string api_secret = "MVQLCDvr8oQErLUwALW0oROyzcU";



    public void AddPhoto()
    {
        Account account = new Account(
        cloud_name,
        api_key,
        api_secret);

        Cloudinary cloudinary = new Cloudinary(account);

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(@"https://upload.wikimedia.org/wikipedia/commons/a/ae/Olympic_flag.jpg"),
            PublicId = "olympic_flag"
        };
        var uploadResult = cloudinary.Upload(uploadParams);
    }

    public async Task<string> FileCreateAsync(IFormFile file)
    {
        string fileName = string.Concat(Guid.NewGuid(), file.FileName);
        var myAccount = new Account { ApiKey = api_key, ApiSecret = api_secret, Cloud = cloud_name };
        //var _cloudinary = new Cloudinary(myAccount);

        Cloudinary _cloudinary = new Cloudinary("cloudinary://646523828955691:MVQLCDvr8oQErLUwALW0oROyzcU@dlilcwizx/atlet.az");
        _cloudinary.Api.Secure = true;
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }
            string url=uploadResult.SecureUri.ToString();
        return url;
    }
}
