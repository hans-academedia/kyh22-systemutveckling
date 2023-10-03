namespace DataAccess.Models;

public class DeviceItem
{
	public string DeviceId { get; set; } = null!;
	public string DeviceType { get; set; } = null!;
	public string Manufacturer { get; set; } = null!;
	public string Location { get; set; } = null!;
	public bool IsActive { get; set; }

}
