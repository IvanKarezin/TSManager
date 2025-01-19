using System.ComponentModel;
using System.IO;
using System.Text.Json;

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
        //Необходимо из-за ньюансов сериализации в json
        File.Delete("appsettings.json");
        await using var fileStream = new FileStream("appsettings.json", FileMode.OpenOrCreate);
        await JsonSerializer.SerializeAsync(fileStream, AppSettings);
    }
}