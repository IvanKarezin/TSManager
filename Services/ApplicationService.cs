using System;
using TSManager.Models;

namespace TSManager.Services;

public class ApplicationService(IApplicationContext applicationContext) : IApplicationService
{
    public IApplicationContext ApplicationContext { get; } = applicationContext;

    public WorkingWeek BuildWeek()
    {
        throw new System.NotImplementedException();
    }

    public WorkingDay BuildDay()
    {
        throw new System.NotImplementedException();
    }

    public void Import()
    {
        throw new System.NotImplementedException();
    }

    public void Export()
    {
        throw new System.NotImplementedException();
    }
}