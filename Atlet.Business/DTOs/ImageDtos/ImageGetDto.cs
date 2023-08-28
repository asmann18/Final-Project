using Atlet.Business.DTOs.Abstract;

namespace Atlet.Business.DTOs.ImageDtos;

public class ImageGetDto:IDto
{
    public string Path { get; set; }
    public string Alt { get; set; }
}
