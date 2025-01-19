using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using TSManager.Services;
using TSManager.Settings;

namespace TSManager.ViewModels;

public partial class MainWindowViewModel(IApplicationService applicationService) : ViewModelBase
{
    private RelayCommand<string>? _exampleCommand;
    
    public IApplicationService ApplicationService { get; } = applicationService;

    public RelayCommand<string> ExampleCommand => this._exampleCommand ?? this.ExampleCommandText();

    private RelayCommand<string> ExampleCommandText()
    {
        return new RelayCommand<string>((msg) =>
        {
            var msBox = MessageBoxManager.GetMessageBoxStandard("", msg ?? "").ShowAsync();
        });
    }
}