using DemoJWT_MySQL.DTO.User;
using DemoJWT_MySQL.DTO;

namespace DemoJWT_MySQL.Services.Interface
{
    public interface IUserService
    {
        Task<ErrorModel> Register(RegisterModel model);
        Task<ErrorModel> Login(LoginModel model);
    }
}
