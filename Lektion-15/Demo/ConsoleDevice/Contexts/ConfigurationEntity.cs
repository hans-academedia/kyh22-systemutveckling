using System.ComponentModel.DataAnnotations;

namespace ConsoleDevice.Contexts;

internal class ConfigurationEntity
{
    [Key]
    public string DeviceId { get; set; } = "EF:12:AC:17:B4";
    public string ConnectionString { get; set; } = null!;
    public string? DeviceType { get; set; }
    public string? Location { get; set; }
}
