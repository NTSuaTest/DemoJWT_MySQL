using DemoJWT_MySQL.DTO.Image;
using DemoJWT_MySQL.Entity;
using DemoJWT_MySQL.Services.Interface;

namespace DemoJWT_MySQL.Services.Implement
{
    public class ImageService : IImageService
    {
        private readonly ApiDbContext _dbcontext;

        public ImageService(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<ImageDTO> getImage()
        {
            return _dbcontext.Images.Select(x => new ImageDTO(x.Url)).ToList();
        }
    }
}
