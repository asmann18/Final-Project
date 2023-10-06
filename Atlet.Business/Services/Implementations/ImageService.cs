using Atlet.Business.DTOs.Common;
using Atlet.Business.Services.Interfaces;
using Atlet.Business.Services.Interfaces.E_Commerce;
using Atlet.Business.Services.Interfaces.ManyToMany;
using Atlet.Core.Entities;
using Atlet.Core.Entities.E_Commerce;
using Atlet.Core.Entities.Moves;
using Atlet.DataAccess.Repostories.Interfaces;
using AutoMapper;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atlet.Business.Services.Implementations;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IProductImageService _productImageService;
    private readonly IMoveImageService _moveImageService;
    private readonly IBlogImageService _blogImageService;
    private readonly ICloudinaryService _cloudinaryService;


    public ImageService(IImageRepository imageRepository, IProductImageService productImageService, IMoveImageService moveImageService, IBlogImageService blogImageService, ICloudinaryService cloudinaryService)
    {
        _imageRepository = imageRepository;
        _productImageService = productImageService;
        _moveImageService = moveImageService;
        _blogImageService = blogImageService;
        _cloudinaryService = cloudinaryService;
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

    //public async Task CreateProductImages(int productId, IFormFile[] images);
    //{
    //string[] hi={"Ads"};
    //    foreach (string path in hi)
    //    {
    //        Image image = new Image(path);
    //        await _imageRepository.CreateAsync(image);
    //       await _productImageService.CreateProductImage(productId,image.Id);
    //    }
    //    return;

    //}

    public async Task CreateProductImages(int productId, IFormFile[] images)
    {
        foreach (IFormFile img in images)
        {
           
            Image image = new Image(await _cloudinaryService.FileCreateAsync(img));
            await _imageRepository.CreateAsync(image);
            await _productImageService.CreateProductImage(productId, image.Id);
        }
        return;
    }

    public async Task DeleteProductImages(int productId)
    {
        await _productImageService.DeleteProductImages(productId);
    }
    public async Task UpdateProductImages(int productId, IFormFile[] images)
    {
        await DeleteProductImages(productId);
        await CreateProductImages(productId,images);
    }













    public async Task CreateBlogImages(int blogId, IFormFile[] images)
    {
        foreach (var img in images)
        {
            Image image = new Image(await _cloudinaryService.FileCreateAsync(img));
            await _imageRepository.CreateAsync(image);
            await _blogImageService.CreateBlogImage(blogId, image.Id);
        }
        return;
    }

    public async Task DeleteBlogImages(int blogId)
    {
        await _blogImageService.DeleteBlogImages(blogId);
    }
    public async Task UpdateBlogImages(int blogId, IFormFile[] images)
    {
        await DeleteBlogImages(blogId);
        await CreateBlogImages(blogId, images);
    }








    public async Task CreateMoveImages(int moveId, IFormFile[] images)
    {
        foreach (var img in images)
        {
            Image image = new Image(await _cloudinaryService.FileCreateAsync(img));
            await _imageRepository.CreateAsync(image);
            await _moveImageService.CreateMoveImage(moveId, image.Id);
        }
        return;
    }
    public async Task DeleteMoveImages(int moveId)
    {
        await _moveImageService.DeleteMoveImages(moveId);
    }
    public async Task UpdateMoveImages(int moveId, IFormFile[] images)
    {
        await DeleteMoveImages(moveId);
        await CreateMoveImages(moveId, images);
    }







    public async Task<int> CreateImage(IFormFile img)
    {
        Image image=new Image(await _cloudinaryService.FileCreateAsync(img));
        await _imageRepository.CreateAsync(image);
        return image.Id;
    }

    public async Task<ResultDto> DeleteImage(int imageID)
    {
        var image=await _imageRepository.GetByIdAsync(imageID);
        if(image is not null)
        {
            _imageRepository.Delete(image);
            await _imageRepository.SaveAsync();
            return new ResultDto("Image is successfully deleted");
        }
        return new(false,"Image not found");
    }

    public async Task<int> UpdateImage(int imageId, IFormFile img)
    {
        await DeleteImage(imageId); 
        var id=await CreateImage(img); 
        return id;
    }
}
