using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCloset.Frontend.Blazor.Services;
using System.Reflection;

namespace MyCloset.Frontend.Blazor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MyCloset.Frontend.Blazor.appsettings.json");
        var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<IRedisService, RedisService>();
        builder.Configuration.AddConfiguration(config);

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
