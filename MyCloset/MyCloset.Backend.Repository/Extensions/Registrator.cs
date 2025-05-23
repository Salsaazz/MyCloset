using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;
using MyCloset.Backend.Infrastructure.Repositories;

namespace MyCloset.Backend.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
        }

        private static void RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<MyClosetContext>(options =>
                options.UseSqlite("name=ConnectionStrings:MyClosetDB"));
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClothingRepository, ClothingRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}
