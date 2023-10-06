using Atlet.Business.Services.Implementations;
using Atlet.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryController : ControllerBase
    {
        private readonly ICloudinaryService _cloudinaryService;

        public CloudinaryController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddPhoto(IFormFile file)
        {
           
            return Ok(await _cloudinaryService.FileCreateAsync(file));
        }
    }
}
