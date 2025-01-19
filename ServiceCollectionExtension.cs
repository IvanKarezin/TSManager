using System.Runtime.InteropServices;
using DesktopNotifications;
using DesktopNotifications.FreeDesktop;
using DesktopNotifications.Windows;
using Microsoft.Extensions.DependencyInjection;
using TSManager.Services;
using TSManager.Settings;
using ApplicationContext = TSManager.Services.ApplicationContext;

namespace TSManager;

public static class ServiceCollectionExtension
{
    public static void AddServiceCollection(this IServiceCollection services)
    {
        services.AddSingleton<ISettingsProvider, SettingsProvider>();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            services.AddTransient<INotificationManager, WindowsNotificationManager>();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            services.AddTransient<INotificationManager, FreeDesktopNotificationManager>();

        services.AddSingleton<IApplicationContext, ApplicationContext>();
        services.AddTransient<IApplicationService, ApplicationService>();
    }
}