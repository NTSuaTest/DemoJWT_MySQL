using DemoJWT_MySQL.DTO.Image;
using DemoJWT_MySQL.Entity;
using DemoJWT_MySQL.Helper;
using DemoJWT_MySQL.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoJWT_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = RoleConstant.Admin)]
        public List<ImageDTO> getImage()
        {
            return _imageService.getImage();
        }

        [HttpGet("GetByToken")]
        [Authorize(Roles = RoleConstant.Admin + "," + RoleConstant.Citizen)]
        public List<ImageDTO> getImageByToken()
        {
            return _imageService.getImageByToken();
        }
    }
}
