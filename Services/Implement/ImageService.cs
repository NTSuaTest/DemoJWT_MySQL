using DemoJWT_MySQL.DTO.Image;
using DemoJWT_MySQL.Entity;
using DemoJWT_MySQL.Helper;
using DemoJWT_MySQL.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace DemoJWT_MySQL.Services.Implement
{
    public class ImageService : IImageService
    {
        private readonly ApiDbContext _dbcontext;
        private readonly UserResolverService _userResolverService;

        public ImageService(ApiDbContext dbcontext, UserResolverService userResolverService)
        {
            _dbcontext = dbcontext;
            _userResolverService = userResolverService;
        }

        public List<ImageDTO> getImage()
        {
            return _dbcontext.Images.Select(x => new ImageDTO(x.Url)).ToList();
        }

        public List<ImageDTO> getImageByToken()
        {
            string accountId = _userResolverService.GetUser();
            return _dbcontext.Images.Where(x => x.UserId == accountId).Select(x => new ImageDTO(x.Url)).ToList();
        }
    }
}
