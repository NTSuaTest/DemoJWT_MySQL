using System.ComponentModel.DataAnnotations;
using DemoJWT_MySQL.Helper;

namespace DemoJWT_MySQL.DTO.User
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceName = "UsernameRequired", ErrorMessageResourceType = typeof(ErrorResource))]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(ErrorResource))]
        public string Password { get; set; }
    }
}
