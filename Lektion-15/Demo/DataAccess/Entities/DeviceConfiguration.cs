using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class DeviceConfiguration
{
    [Key]
    public string DeviceId { get; set; } = null!;
    public string? DeviceConnectionString { get; set; }
    public string? DeviceType { get; set; }
    public string? DeviceLocation { get; set; }
}
