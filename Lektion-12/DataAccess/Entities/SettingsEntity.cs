using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class SettingsEntity
{
	[Key]
	public string ConnectionString { get; set; } = null!;
}
