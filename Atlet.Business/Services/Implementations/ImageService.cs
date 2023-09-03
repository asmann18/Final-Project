using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Business.Services.Interfaces.E_Commerce.ManyToMany;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using AutoMapper;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Atlet.Business.Services.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IProductImageService _productImageService;
    private readonly IMoveImageService _moveImageService;
    private readonly IBlogImageService _blogImageService;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ImageService(IImageRepository imageRepository, IProductService productService, IMapper mapper, IProductImageService productImageService, IMoveImageService moveImageService, IBlogImageService blogImageService, IWebHostEnvironment webHostEnvironment)
    {
        _imageRepository = imageRepository;
        _productService = productService;
        _mapper = mapper;
        _productImageService = productImageService;
        _moveImageService = moveImageService;
        _blogImageService = blogImageService;
        _webHostEnvironment = webHostEnvironment;
    }
    IFirebaseConfig config = new FirebaseConfig
    {
        AuthSecret= "9ifRStijpVHAk71oj3XCkhkl410Q0Frn3jyZJCDL",
        BasePath= "https://atlet-az-finalproject-default-rtdb.firebaseio.com/"
    };

    public async Task<List<string>> GetBlogImageUrlsByIdasync(int BlogId)
    {
        var BlogImages=await _blogImageService.GetBlogImageUrlsByIdAsync(BlogId);
        List<string> urls = new List<string>();
        foreach (var blogImage in BlogImages)
        {
            urls.Add((await _imageRepository.GetByIdAsync(blogImage.ImageId)).Path);
        }
        return urls;
    }

    public async Task<string> GetBrandImageUrlByIdasync(Brand brand)
    {
        var BrandImage = await _imageRepository.GetByIdAsync(brand.ImageId);
        return BrandImage.Path;
    }

    public async Task<List<string>> GetMoveImageUrlsByIdasync(int MoveId)
    {
        var MoveImages=await _moveImageService.GetMoveImageUrlsByIdAsync(MoveId);
        List<string> urls = new List<string>();
        foreach (var MoveImage in MoveImages)
        {
            urls.Add((await _imageRepository.GetByIdAsync(MoveImage.ImageId)).Path);
        }
        return urls;
    }

    public async Task<string> GetPartImageUrlByIdasync(Part part)
    {
        var PartImage =await _imageRepository.GetByIdAsync(part.ImageId);
        return PartImage.Path;
    }

    public async Task<List<string>> GetProductImageUrlsByIdAsync(int ProductID)
    {
        var productImages=await _productImageService.GetProductImageUrlsByIdAsync(ProductID);
        List<string> urls = new List<string>();
        foreach (var productImage in productImages)
        {
            urls.Add((await _imageRepository.GetByIdAsync(productImage.ImageId)).Path);
        }

        return urls;
        ;
    }
}
