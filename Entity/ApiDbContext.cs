using DemoJWT_MySQL.Extentions;
using DemoJWT_MySQL.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DemoJWT_MySQL.Entity
{
    public class ApiDbContext : IdentityDbContext<User, UserRole, string, IdentityUserClaim<string>,
                                                UserRoleMap, IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public static ApiDbContext Create(DbContextOptions<ApiDbContext> options)
        {
            return new ApiDbContext(options);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            base.OnModelCreating(builder);

            //Configration relationship
            builder.ConfigrationRelationship();
            //Seed
            builder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRoleMap> UserRoleMaps { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
