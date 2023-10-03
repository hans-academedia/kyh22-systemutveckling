using DataAccess.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class ZeniAppDbContext : DbContext
{
	public ZeniAppDbContext()
	{
	}
	
	public ZeniAppDbContext(DbContextOptions<ZeniAppDbContext> options) : base(options)
	{
		Database.EnsureCreated();
		try
		{
			Database.Migrate();
		}
		catch { }
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite();
	}

	public DbSet<ZeniAppSettings> Settings { get; set; }
}
