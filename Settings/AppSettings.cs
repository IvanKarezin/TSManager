using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TSManager.Settings;

public sealed class AppSettings(string? test = "test") : IAppSettings
{
    private string? _test = test;

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