using System.Runtime.CompilerServices;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;

namespace TSManager.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private RelayCommand<string>? _exampleCommand;

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