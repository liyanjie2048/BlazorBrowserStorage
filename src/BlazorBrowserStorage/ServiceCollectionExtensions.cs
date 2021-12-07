using Liyanjie.Blazor.BrowserStorage;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBrowserStorage(this IServiceCollection services)
    {
        services.AddScoped<LocalStorage>();
        services.AddScoped<SessionStorage>();

        return services;
    }
}
