using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TSManager.Views;

public partial class MainWindow : Window
{
    private readonly AddWindow _addWindow;
    public MainWindow()
    {
        InitializeComponent();
        this._addWindow = new AddWindow();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var result = await this._addWindow.ShowDialog<string>(this);
        this._addWindow.Show();
    }
}