using Liyanjie.Blazor.BrowserStorage;

using Microsoft.JSInterop;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBrowserStorage(this IServiceCollection services,
        bool base64Encode = true)
    {
        services.AddScoped<LocalStorage>(serviceProvider => new(serviceProvider.GetRequiredService<IJSRuntime>(), base64Encode));
        services.AddScoped<SessionStorage>(serviceProvider => new(serviceProvider.GetRequiredService<IJSRuntime>(), base64Encode));

        return services;
    }
}
