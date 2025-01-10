using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TSManager.Settings;


public sealed class SettingsProvider : ISettingsProvider
{
    public IAppSettings AppSettings { get; }

    public SettingsProvider()
    {
        var fileStream = new FileStream("appsettings.json", FileMode.OpenOrCreate);
        try
        {
            AppSettings = JsonSerializer.Deserialize<AppSettings>(fileStream) ?? new AppSettings();
        }
        catch (JsonException e)
        {
            AppSettings = new AppSettings();
        }
        finally
        {
            fileStream.Dispose();
        }
        AppSettings.PropertyChanged += AppSettingsOnPropertyChanged;
    }

    private async void AppSettingsOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        await using var fileStream = new FileStream("appsettings.json", FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync(fileStream, AppSettings);
    }
}