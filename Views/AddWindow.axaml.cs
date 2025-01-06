using Avalonia.Controls;
using Avalonia.Interactivity;


namespace TSManager.Views;

public partial class AddWindow : Window
{
    private bool _autostart;
    
    public AddWindow(Window owner, bool autoStart = false)
    {
        InitializeComponent();
        this._autostart = autoStart;
        if (!autoStart) return;
        
        this.SetInvisibleTimePeriodsAndCurrentProperty();
        this.IsExecLabel.IsVisible = false;
        this.IsExec.IsVisible = false;
    }

    private void SetInvisibleTimePeriodsAndCurrentProperty()
    {
        this.BeginLabel.IsVisible = false;
        this.BeginPicker.IsVisible = false;
        this.EndLabel.IsVisible = false;
        this.EndPicker.IsVisible = false;
        this.IsExecLabel.IsVisible = false;
        this.IsExec.IsVisible = false;
        this.CurrentTaskPolicyLabel.IsVisible = false;
        this.SuspenseCurrent.IsVisible = false;
        this.StopCurrent.IsVisible = false;
    }

    private void SetReadOnlyTimePeriodsAndCurrentProperty()
    {
        if (this.IsExec.IsChecked ?? false)
        {
            this.BeginPicker.IsEnabled = false;
            this.EndPicker.IsEnabled = false;
            this.SuspenseCurrent.IsEnabled = true;
            this.StopCurrent.IsEnabled = true;
            return;
        }
        
        this.BeginPicker.IsEnabled = true;
        this.EndPicker.IsEnabled = true;
        this.SuspenseCurrent.IsEnabled = false;
        this.StopCurrent.IsEnabled = false;
    }

    private void Ok_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if(this._autostart) this.Owner?.Hide();
        this.Close(this.ActivityDescription.Text);
    }

    private void IsExec_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        this.SetReadOnlyTimePeriodsAndCurrentProperty();
    }
}