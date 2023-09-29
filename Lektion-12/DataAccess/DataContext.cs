using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DataContext : DbContext
{
	public DataContext()
	{
		//if (!Database.EnsureCreated())
		//	Database.Migrate();
	}

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
		//if (!Database.EnsureCreated())
		//	Database.Migrate();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite();
	}

	public DbSet<SettingsEntity> Settings { get; set; }
}
