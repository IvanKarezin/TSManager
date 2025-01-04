using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace TSManager.Views;

public partial class MainWindow : Window
{
    private readonly AddWindow _addWindow;

    public MainWindow()
    {
        InitializeComponent();
        this._addWindow = new AddWindow();
        this.Closing += (sender, args) =>
        {
            ((Window)sender)?.Hide();
            args.Cancel = true;
        };
    }

    public async Task<string> ShowAddDialog()
    {
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
        var result = await this._addWindow.ShowDialog<string>(this);
        this._addWindow.Show();
        
        return result;
    }
    
    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var result = await this.ShowAddDialog();
        
        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
    }
}