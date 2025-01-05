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
        this.BeginLabel.IsVisible = false;
        this.BeginPicker.IsVisible = false;
        this.EndLabel.IsVisible = false;
        this.EndPicker.IsVisible = false;
    }

    private void Ok_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if(this._autostart) this.Owner?.Hide();
        this.Close(this.ActivityDescription.Text);
    }
}