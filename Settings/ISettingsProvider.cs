namespace TSManager.Settings;

public interface ISettingsProvider
{
    public IAppSettings AppSettings { get; }
}