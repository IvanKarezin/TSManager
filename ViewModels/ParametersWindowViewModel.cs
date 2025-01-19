using TSManager.Settings;
using TSManager.Views;

namespace TSManager.ViewModels;

public class ParametersWindowViewModel(IAppSettings settings) : ViewModelBase
{
    public IAppSettings Settings { get; } = settings;
}