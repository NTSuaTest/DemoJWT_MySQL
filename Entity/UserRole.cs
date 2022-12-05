using Microsoft.AspNetCore.Identity;

namespace DemoJWT_MySQL.Entity
{
    public class UserRole : IdentityRole
    {
        public virtual ICollection<UserRoleMap> AccountRoleMaps { get; set; }
    }
}

