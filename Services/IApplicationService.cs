using TSManager.Models;

namespace TSManager.Services;

public interface IApplicationService
{
    public IApplicationContext ApplicationContext { get; }
    
    public WorkingWeek BuildWeek();
    
    public WorkingDay BuildDay();

    public void Import();
    
    public void Export();
}