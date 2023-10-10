using Microsoft.EntityFrameworkCore;

namespace ConsoleDevice.Contexts;

internal class DataContext : DbContext
{
    public DataContext()
    {
        Database.Migrate();
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<ConfigurationEntity> Configuration { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Database.sqlite.db");
    }
}
