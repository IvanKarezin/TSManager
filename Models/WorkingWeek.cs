using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TSManager.Models;

public class WorkingWeek : ObservableObject
{
    private bool _canEdit = true;
    
    [Key]
    public int Id { get; set; }

    [Required]
    public bool CanEdit
    {
        get => _canEdit;
        set
        {
            _canEdit = value;
            OnPropertyChanged(nameof(CanEdit));
        }
    }

    public ObservableCollection<WorkingDay> WorkingDays { get; set; } = null!;
}