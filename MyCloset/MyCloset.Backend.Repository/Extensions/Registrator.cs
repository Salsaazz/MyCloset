using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyCloset.Backend.Infrastructure.Contexts;

namespace MyCloset.Backend.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
        }

        private static void RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<MyClosetContext>(options =>
                options.UseSqlite("name=ConnectionStrings:MyClosetDB"));
        }
    }
}
