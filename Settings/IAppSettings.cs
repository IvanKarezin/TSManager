using System.ComponentModel;

namespace TSManager.Settings;

public interface IAppSettings : INotifyPropertyChanged
{
    public string? Test { get; set; }
}