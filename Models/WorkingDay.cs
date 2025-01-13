using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TSManager.Models;

public class WorkingDay(
        DateTime beginDateTime,
        DateTime endDateTime,
        DateTime breakTime,
        int breakDurationInMinutes,
        int workingWeekId,
        int? currentActivityId
    ) : ObservableObject
{
    private DateTime _beginDateTime = beginDateTime;
    private DateTime _endDateTime = endDateTime;
    private DateTime _breakTime = breakTime;
    private int _breakDurationInMinutes = breakDurationInMinutes;
    private int? _currentActivityId = currentActivityId;
    private int _workingWeekId = workingWeekId;
    private WorkingWeek _workingWeek = null!;
    private Activity? _currentActivity = null!;
    
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime BeginDateTime
    {
        get => _beginDateTime;
        set
        {
            _beginDateTime = value;
            OnPropertyChanged(nameof(BeginDateTime));
        }
    }

    [Required]
    public DateTime EndDateTime
    {
        get => _endDateTime;
        set
        {
            _endDateTime = value;
            OnPropertyChanged(nameof(EndDateTime));
        }
    }

    [Required]
    public DateTime BreakTime
    {
        get => _breakTime;
        set
        {
            _breakTime = value;
            OnPropertyChanged(nameof(BreakTime));
        }
    }

    [Required]
    public int BreakDurationInMinutes
    {
        get => _breakDurationInMinutes;
        set
        {
            _breakDurationInMinutes = value;
            OnPropertyChanged(nameof(BreakDurationInMinutes));
        }
    }
    [Required] 
    public ObservableCollection<Activity> Activities { get; set; } = [];

    [Required]
    public int WorkingWeekId
    {
        get => _workingWeekId;
        set
        {
            _workingWeekId = value;
            OnPropertyChanged(nameof(WorkingWeekId));
        }
    }
    
    public WorkingWeek WorkingWeek
    {
        get => _workingWeek;
        set
        {
            _workingWeek = value;
            OnPropertyChanged(nameof(WorkingWeek));
        }
    }

    public int? CurrentActivityId
    {
        get => _currentActivityId;
        set
        {
            _currentActivityId = value;
            OnPropertyChanged(nameof(CurrentActivityId));
        }
    }

    public Activity? CurrentActivity
    {
        get => _currentActivity;
        set
        {
            _currentActivity = value;
            OnPropertyChanged(nameof(CurrentActivity));
        }
    }
}