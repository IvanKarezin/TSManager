using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

namespace TSManager.Settings;

public sealed class AppSettings(
        bool workingDayLimitation = true,
        bool tsRoundingUp = true,
        int tsMultiplicity = 60,
        string taskPrefix = "Optimacros",
        string workingDayDefaultBegin = "09:00",
        string workingDayDefaultBrakeBegin = "14:00",
        int workingDayBrakeDuration = 60,
        string? tsPath = null
    ) : IAppSettings
{

    private bool _workingDayLimitation = workingDayLimitation;
    private bool _tsRoundUp = tsRoundingUp;
    private int _tsMultiplicity = tsMultiplicity;
    private string _taskPrefix = taskPrefix;
    private string _workingDayDefaultBegin = workingDayDefaultBegin;
    private string _workingDayDefaultBrakeBegin = workingDayDefaultBrakeBegin;
    private int _workingDayBrakeDuration = workingDayBrakeDuration;
    private string _tsPath = tsPath ?? Directory.GetCurrentDirectory();
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public bool WorkingDayLimitation
    {
        get => _workingDayLimitation;
        set
        {
            _workingDayLimitation = value;
            OnPropertyChanged(nameof(WorkingDayLimitation));
        }
    }

    public bool TsRoundingUp
    {
        get => _tsRoundUp;
        set
        {
            _tsRoundUp = value;
            OnPropertyChanged(nameof(TsRoundingUp));
        }
    }

    public int TsMultiplicity
    {
        get => _tsMultiplicity;
        set
        {
            _tsMultiplicity = value;
            OnPropertyChanged(nameof(TsMultiplicity));
        }
    }

    public string TaskPrefix
    {
        get => _taskPrefix;
        set
        {
            _taskPrefix = value;
            OnPropertyChanged(nameof(TaskPrefix));
        }
    }

    public string WorkingDayDefaultBegin
    {
        get => _workingDayDefaultBegin;
        set
        {
            _workingDayDefaultBegin = value;
            OnPropertyChanged(nameof(WorkingDayDefaultBegin));
        }
    }

    public string WorkingDayDefaultBrakeBegin
    {
        get => _workingDayDefaultBrakeBegin;
        set
        {
            _workingDayDefaultBrakeBegin = value;
            OnPropertyChanged(nameof(WorkingDayDefaultBrakeBegin));
        }
    }

    public int WorkingDayBrakeDuration
    {
        get => _workingDayBrakeDuration;
        set
        {
            _workingDayBrakeDuration = value;
            OnPropertyChanged(nameof(WorkingDayBrakeDuration));
        }
    }

    public string TsPath
    {
        get => _tsPath;
        set
        {
            _tsPath = value;
            OnPropertyChanged(nameof(TsPath));
        }
    }
}