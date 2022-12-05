using DemoJWT_MySQL.DTO.Image;
using DemoJWT_MySQL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoJWT_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public List<ImageDTO> getImage()
        {
            return _imageService.getImage();
        }
    }
}
