using System;
using TSManager.Settings;

namespace TSManager.Services;

public class ApplicationContext(ISettingsProvider settingsProvider) : IApplicationContext
{
    public IAppSettings AppSettings => settingsProvider.AppSettings;
    public IActivityDispatcher ActivityDispatcher => throw new NotImplementedException();
}