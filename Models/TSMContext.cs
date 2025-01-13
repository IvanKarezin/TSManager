using Microsoft.EntityFrameworkCore;

namespace TSManager.Models;

public class TsmContext : DbContext
{
    public DbSet<WorkingWeek> WorkingWeeks { get; set; } = null!;
    public DbSet<WorkingDay> WorkingDays { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tsm.db");
    }
}