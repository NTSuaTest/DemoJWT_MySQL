using DemoJWT_MySQL.DTO.Image;

namespace DemoJWT_MySQL.Services.Interface
{
    public interface IImageService
    {
        List<ImageDTO> getImage();
        List<ImageDTO> getImageByToken();
    }
}
