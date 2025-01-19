using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using TSManager.Services;
using TSManager.Settings;

namespace TSManager.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private RelayCommand<string>? _exampleCommand;
    private readonly IApplicationService _applicationService;
    private readonly IAppSettings _settings;

    public MainWindowViewModel(IApplicationService applicationService)
    {
        _applicationService = applicationService;
        this._settings = this._applicationService.ApplicationContext.AppSettings;
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