using System.Runtime.CompilerServices;

namespace TSManager.Settings;

using Microsoft.Extensions.Configuration;

public sealed class SettingsProvider : ISettingsProvider
{
    public IAppSettings AppSettings { get; }

    public SettingsProvider()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        this.AppSettings = new AppSettings(configuration.GetSection("AppSettings"));
    }
}