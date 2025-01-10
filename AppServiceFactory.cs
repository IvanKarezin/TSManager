using System;
using Microsoft.Extensions.DependencyInjection;
using TSManager.Settings;

namespace TSManager;

public static class AppServiceFactory
{
    private static readonly IServiceCollection Services;

    static AppServiceFactory()
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