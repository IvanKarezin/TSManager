using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using TSManager.ViewModels;
using TSManager.Views;

namespace TSManager;

public partial class App : Application
{
    private MainWindow? _mainWindow;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            
            this._mainWindow = desktop.MainWindow as MainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private void NativeMenuItem_OnClick(object? sender, EventArgs e)
    {
        this._mainWindow?.Show();
    }

    private void NativeMenuItem_Close_OnClick(object? sender, EventArgs e)
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }

    private async void NativeMenuItem_AddWithSuspense_OnClick(object? sender, EventArgs e)
    {
        var result = this._mainWindow?.ShowAddDialog();
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
    }

    private async void NativeMenuItem_WithStop_OnClick(object? sender, EventArgs e)
    {
        var result = this._mainWindow?.ShowAddDialog();
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
    }
}