using Microsoft.AspNetCore.Identity;

namespace DemoJWT_MySQL.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<UserRoleMap> AccountRoleMaps { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
