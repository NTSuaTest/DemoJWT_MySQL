using DemoJWT_MySQL.Entity;
using DemoJWT_MySQL.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace DemoJWT_MySQL.Extentions
{
    public static class ConfigrationCustomDB
    {
        public static void ConfigrationRelationship(this ModelBuilder builder)
        {
            builder.Entity<UserRoleMap>(userRole =>
            {
                userRole.HasKey(ur => new { ur.RoleId, ur.UserId });

                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.AccountRoleMaps)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.AccountRoleMaps)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            builder.Entity<Image>(i =>
            {
                i.HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.UserId)
                .IsRequired();
            });
        }

        public static void Seed(this ModelBuilder builder)
        {
            var roleIdAdmin = new string("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleIdCitizen = new string("1B3D7E19-B1A5-4CA2-A491-54593FA16531");
            builder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = roleIdAdmin,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new UserRole
                {
                    Id = roleIdCitizen,
                    Name = "Citizen",
                    NormalizedName = "CITIZEN"
                }
            );

            var adminId = new string("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var citizenId = new string("70BD714F-9576-45BA-B5B7-F00649BE00DE");
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    UserName = DefaultAdmin.Email,
                    NormalizedUserName = DefaultAdmin.Email.ToUpper(),
                    Email = DefaultAdmin.Email,
                    NormalizedEmail = DefaultAdmin.Email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEOHgDAPys3OktSdFo+EcfLLuiNNUsqCzLGsXvMEQ7ufUzdO5VWUEZwPXCk63zld4aA==",
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "Admin",
                    ConcurrencyStamp = "ba637654-70af-4542-be74-08c7b7329679",
                },
                new User
                {
                    Id = citizenId,
                    UserName = DefaultUser.Email,
                    NormalizedUserName = DefaultUser.Email.ToUpper(),
                    Email = DefaultUser.Email,
                    NormalizedEmail = DefaultUser.Email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEOHgDAPys3OktSdFo+EcfLLuiNNUsqCzLGsXvMEQ7ufUzdO5VWUEZwPXCk63zld4aA==",
                    SecurityStamp = string.Empty,
                    FirstName = "Citizen",
                    LastName = "Citizen",
                    ConcurrencyStamp = "ba637654-70af-4542-be74-08c7b7329679",
                }
            );

            builder.Entity<UserRoleMap>().HasData(
                new UserRoleMap
                {
                    RoleId = roleIdAdmin,
                    UserId = adminId
                },
                new UserRoleMap
                {
                    RoleId = roleIdCitizen,
                    UserId = citizenId
                }
            );

            builder.Entity<Image>().HasData(
                new Image()
                {
                    Id = Guid.NewGuid(),
                    UserId = citizenId,
                    Url = "https://lh3.googleusercontent.com/a/AEdFTp5O41syiiOXKyYwoNE8UWt4mp2GAszsgxyV3n_C=s317-p-rw-no"
                },
                new Image()
                {
                    Id = Guid.NewGuid(),
                    UserId = citizenId,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Stack_Overflow_icon.svg/768px-Stack_Overflow_icon.svg.png"
                },
                new Image()
                {
                    Id = Guid.NewGuid(),
                    UserId = adminId,
                    Url = "https://upload.wikimedia.org/wikipedia/commons/0/0f/Pepsi_logo_2014.svg"
                }
            );
        }
    }
}
