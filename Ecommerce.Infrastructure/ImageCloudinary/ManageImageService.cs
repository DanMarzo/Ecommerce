using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.ImageManagement;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

namespace Ecommerce.Infrastructure.ImageCloudinary;

public class ManageImageService : IManageImageService
{
    public CloudinarySettings _cloudinarySettings { get; set; }
    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettings) => _cloudinarySettings = cloudinarySettings.Value;
    public async Task<ImageResponse> UploadImage(ImageData imageStream)
    {

        //Cloud = CloudinaryConfiguration.CloudName;
        //ApiKey = CloudinaryConfiguration.ApiKey;
        //ApiSecret = CloudinaryConfiguration.ApiSecret;
        Account account = new Account(
            _cloudinarySettings.CloudName,
            _cloudinarySettings.ApiKey,
            _cloudinarySettings.ApiSecret
            );

        var cloudinary = new Cloudinary(account);
        var uploadImage = new ImageUploadParams()
        {
            File = new FileDescription(imageStream.Nome, imageStream.ImageStream)
        };
        var uploadResult = await cloudinary.UploadAsync(uploadImage);

        if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return new ImageResponse
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.ToString()
            };
        }
        throw new Exception("Nao foi possivel guardar a imagem");
    }
}
