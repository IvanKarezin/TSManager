using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TSManager.Models;

public class Activity(
        string? taskHeader,
        string activityDescription,
        int durationInMinutes,
        TimeSpan period,
        bool current,
        int? nextId,
        int? previousId,
        int workingDayId
    ) : ObservableObject
{
    private string? _taskHeader = taskHeader;
    private string _activityDescription = activityDescription;
    private int _durationInMinutes = durationInMinutes;
    private TimeSpan _period = period;
    private bool _current = current;
    private int? _previousId = previousId;
    private Activity? _previous;
    private int? _nextId = nextId;
    private Activity? _next;
    private WorkingDay _workingDay = null!;
    private int _workingDayId = workingDayId;
    
    
    [Key]
    public int Id { get; set; }

    public string? TaskHeader
    {
        get => _taskHeader;
        set
        {
            _taskHeader = value;
            OnPropertyChanged(nameof(TaskHeader));
        }
    }

    [Required]
    public string ActivityDescription
    {
        get => _activityDescription;
        set
        {
            _activityDescription = value;
            OnPropertyChanged(nameof(ActivityDescription));
        }
    }

    [Required]
    public int DurationInMinutes
    {
        get => _durationInMinutes;
        set
        {
            _durationInMinutes = value;
            OnPropertyChanged(nameof(DurationInMinutes));
        }
    }

    [Required]
    public TimeSpan Period
    {
        get => _period;
        set
        {
            _period = value;
            OnPropertyChanged(nameof(Period));
        }
    }
    
    [Required]
    public bool Current 
    { 
        get => _current;
        set
        {
            _current = value;
            OnPropertyChanged(nameof(Current));
        }
    }

    public int? PreviousId
    {
        get => _previousId;
        set
        {
            _previousId = value;
            OnPropertyChanged(nameof(PreviousId));
        }
    }

    public Activity? Previous
    {
        get => _previous;
        set
        {
            _previous = value;
            OnPropertyChanged(nameof(Previous));
        }
    }

    public int? NextId
    {
        get => _nextId;
        set
        {
            _nextId = value;
            OnPropertyChanged(nameof(NextId));
        }
    }

    public Activity? Next
    {
        get => _next;
        set
        {
            _next = value;
            OnPropertyChanged(nameof(Next));
        }
    }
    
    public WorkingDay WorkingDay
    {
        get => _workingDay;
        set
        {
            _workingDay = value;
            OnPropertyChanged(nameof(WorkingDay));
        }
    }

    [Required, ForeignKey("Id")]
    public int WorkingDayId
    {
        get => _workingDayId;
        set
        {
            _workingDayId = value;
            OnPropertyChanged(nameof(WorkingDayId));
        }
    }
}