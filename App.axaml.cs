using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using DesktopNotifications;
using TSManager.Services;
using TSManager.ViewModels;
using TSManager.Views;

namespace TSManager;

public partial class App : Application
{
    private readonly IServiceCollection _services;
    private MainWindow? _mainWindow;
    private ExtendCurrentWindow? _extendCurrentWindow;

    public App()
    {
        _services = new ServiceCollection();;
        this._services.AddServiceCollection(); 
    }

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
            using ServiceProvider appServiceProvider = _services.BuildServiceProvider();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(appServiceProvider.GetRequiredService<IApplicationService>()),
            };
            
            this._mainWindow = desktop.MainWindow as MainWindow;

            this._extendCurrentWindow = new ExtendCurrentWindow()
            {
                DataContext = new ExtendCurrentWindowViewModel(),
            };
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
        //this._mainWindow?.Show();
        //var result = await this._mainWindow?.ShowAddDialog(true);
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
        
        this._extendCurrentWindow?.Show();
    }

    private async void NativeMenuItem_WithStop_OnClick(object? sender, EventArgs e)
    {
        this._mainWindow?.Show();
        var result = await this._mainWindow?.ShowAddDialog(true);
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
    }

    private void NativeMenuItem_NextActivity_OnClick(object? sender, EventArgs e)
    {
        using ServiceProvider appServiceProvider = this._services.BuildServiceProvider();
        var mv = appServiceProvider.GetRequiredService<INotificationManager>();
        mv.Initialize();
        var nt = new Notification()
        {
            Title = "TEST",
            Body = "Next Activity",
        };

        mv.ShowNotification(nt, null);
    }
}