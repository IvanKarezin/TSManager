using TSManager.Models;
using TSManager.Settings;

namespace TSManager.Services;

public interface IApplicationContext
{
    public IAppSettings AppSettings { get; }
    
    public IActivityDispatcher ActivityDispatcher { get; }
}