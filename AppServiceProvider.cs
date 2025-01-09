using Microsoft.Extensions.DependencyInjection;
using TSManager.Settings;

namespace TSManager;

public sealed class AppServiceProvider
{
    private static readonly IServiceCollection Services;

    static AppServiceProvider()
    {
        Services = new ServiceCollection();
        Services.AddServiceCollection();
    }

    public static ISettingsProvider GetAppSettingsProvider()
    {
        using ServiceProvider appServiceProvider = Services.BuildServiceProvider();
        return appServiceProvider.GetRequiredService<ISettingsProvider>();
    }
}