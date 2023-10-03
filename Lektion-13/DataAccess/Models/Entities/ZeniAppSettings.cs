using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Entities;

public class ZeniAppSettings
{
	[Key]
	public string ConnectionString { get; set; } = null!;
}
