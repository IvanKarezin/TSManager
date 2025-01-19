using System;
using System.ComponentModel;

namespace TSManager.Settings;

public interface IAppSettings : INotifyPropertyChanged
{
    public bool WorkingDayLimitation { get; set; }
    public bool TsRoundingUp { get; set; }
    public int TsMultiplicity { get; set; }
    public string TaskPrefix { get; set; }
    public string WorkingDayDefaultBegin { get; set; }
    public string WorkingDayDefaultBrakeBegin { get; set; }
    public int WorkingDayBrakeDuration { get; set; }
    public string TsPath { get; set; }
}