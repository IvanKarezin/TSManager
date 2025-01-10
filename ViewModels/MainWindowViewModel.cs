using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using TSManager.Settings;

namespace TSManager.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private RelayCommand<string>? _exampleCommand;
    private readonly IAppSettings _settings;

    public MainWindowViewModel()
    {
        this._settings = AppServiceFactory.GetAppSettingsProvider().AppSettings;
    }
    
    public string? Test { get => _settings.Test; set { _settings.Test = value; OnPropertyChanged(); } }

    public RelayCommand<string> ExampleCommand
    {
        get
        {
            return this._exampleCommand ?? this.ExampleCommandText();
        }
    }

    private RelayCommand<string> ExampleCommandText()
    {
        return new RelayCommand<string>((msg) =>
        {
            var msBox = MessageBoxManager.GetMessageBoxStandard("", msg ?? "").ShowAsync();
        });
    }
}