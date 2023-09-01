using Atlet.Business.DTOs.Common;
using Atlet.Business.DTOs.ImageDtos;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using Atlet.DataAccess.Repostories.Interfaces.ManyToMany;
using AutoMapper;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Atlet.Business.Services.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IMoveImageRepository _moveImageRepository;
    private readonly IBlogImageRepository _blogImageRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ImageService(IImageRepository imageRepository, IProductService productService, IMapper mapper, IProductImageRepository productImageRepository, IMoveImageRepository moveImageRepository, IBlogImageRepository blogImageRepository, IWebHostEnvironment webHostEnvironment)
    {
        _imageRepository = imageRepository;
        _productService = productService;
        _mapper = mapper;
        _productImageRepository = productImageRepository;
        _moveImageRepository = moveImageRepository;
        _blogImageRepository = blogImageRepository;
        _webHostEnvironment = webHostEnvironment;
    }
    IFirebaseConfig config = new FirebaseConfig
    {
        AuthSecret= "9ifRStijpVHAk71oj3XCkhkl410Q0Frn3jyZJCDL",
        BasePath= "https://atlet-az-finalproject-default-rtdb.firebaseio.com/"
    };

    public async Task<List<string>> GetBlogImageUrlsByIdasync(int BlogId)
    {
        var BlogImages=_blogImageRepository.GetFiltered(i=>i.BlogId==BlogId);
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
        var MoveImages=_moveImageRepository.GetFiltered(i=>i.MoveId==MoveId);
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
        var productImages=_productImageRepository.GetFiltered(i=>i.ProductId==ProductID);

        List<string> urls = new List<string>();
        foreach (var productImage in productImages)
        {
            urls.Add((await _imageRepository.GetByIdAsync(productImage.ImageId)).Path);
        }

        return urls;

    }
}
