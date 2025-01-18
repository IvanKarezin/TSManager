using System;
using System.Runtime.InteropServices;
using DesktopNotifications;
using DesktopNotifications.FreeDesktop;
using DesktopNotifications.Windows;
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
    
    public static INotificationManager GetNotificationManager()
    {
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return new WindowsNotificationManager();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return new FreeDesktopNotificationManager();
        
        throw new PlatformNotSupportedException();
    }
}