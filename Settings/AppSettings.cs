using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TSManager.Settings;

public sealed class AppSettings : IAppSettings
{
    private string? _test;

    public AppSettings(string? test = "test")
    {
        _test = test;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    
    public string? Test
    {
        get => _test;
        set
        {
            _test = value;
            OnPropertyChanged("Test");
        }
    }
}