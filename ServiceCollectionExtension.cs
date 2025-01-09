using Microsoft.Extensions.DependencyInjection;
using TSManager.Settings;

namespace TSManager;

public static class ServiceCollectionExtension
{
    public static void AddServiceCollection(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsProvider, SettingsProvider>();
    }
}