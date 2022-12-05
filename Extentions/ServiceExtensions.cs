using DemoJWT_MySQL.Entity;
using DemoJWT_MySQL.Helper;
using DemoJWT_MySQL.Services.Implement;
using DemoJWT_MySQL.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
//using MySql.EntityFrameworkCore.Extensions;

namespace DemoJWT_MySQL.Extentions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddEntityFrameworkMySql().AddDbContext<ApiDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("ApiDbConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ApiDbConnection"))
            ));

            builder.Configuration.Bind("DefaultAdmin", new DefaultAdmin());
            builder.Configuration.Bind("DefaultUser", new DefaultUser());

            return services;
        }

        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
