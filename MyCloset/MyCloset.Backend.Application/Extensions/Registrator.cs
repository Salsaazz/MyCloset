using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyCloset.Backend.Application.Extensions
{
    public static class Registrator
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
