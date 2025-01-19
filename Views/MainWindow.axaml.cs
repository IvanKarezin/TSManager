using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using MsBox.Avalonia;

namespace TSManager.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Closing += (sender, args) =>
        {
            ((Window)sender)?.Hide();
            args.Cancel = true;
        };
    }

    public async Task<string> ShowAddDialog(bool autostart = false)
    {
        var addDialog = new AddWindow(this, autostart);
        var result = await addDialog.ShowDialog<string>(this);
        
        return result;
    }
    
    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var result = await this.ShowAddDialog();
        var box = MessageBoxManager.GetMessageBoxStandard("Result", result).ShowAsync();

        //TODO: вызов соответствующей команды и передача result
        //TODO: создание DTO для TS и передача его команде
    }

    /**
     * TODO: Заменить на биндинг
     */
    private void SetReadOnlyTimePeriodsAndCurrentProperty()
    {
        if (this.IsExec.IsChecked ?? false)
        {
            this.BeginTimePicker.IsEnabled = false;
            this.EndTimePicker.IsEnabled = false;
            this.SuspenseCurrent.IsEnabled = true;
            this.StopCurrent.IsEnabled = true;
            
            return;
        }
        
        this.BeginTimePicker.IsEnabled = true;
        this.EndTimePicker.IsEnabled = true;
        this.SuspenseCurrent.IsEnabled = false;
        this.StopCurrent.IsEnabled = false;
    }

    private void IsExec_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        this.SetReadOnlyTimePeriodsAndCurrentProperty();
    }

    private void ParametersItem_OnClick(object? sender, RoutedEventArgs e)
    {
        var parameters = new ParametersWindow();
        parameters.Show();
    }
}