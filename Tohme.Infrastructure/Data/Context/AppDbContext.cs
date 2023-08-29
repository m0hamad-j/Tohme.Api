using Microsoft.EntityFrameworkCore;

using Tohme.Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Protein> Proteins { get; set; }
    public DbSet<Dumbbell> Dumbbells { get; set; }

    public string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Gyms.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
