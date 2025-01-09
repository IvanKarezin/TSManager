using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace TSManager.Settings;

public sealed class AppSettings(IConfigurationSection section) : IAppSettings
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    
    public string? Test
    {
        get => section["Test"];
        set
        {
            //TODO: не робит - надо сохранять руками через IO
            section.GetSection("Test").Value = value;
            OnPropertyChanged("Test");
        }
    }
}