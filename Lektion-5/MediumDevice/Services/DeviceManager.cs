namespace MediumDevice.Services;

internal class DeviceManager
{
	public DeviceConfig Configuration { get; set; }

	public DeviceManager(string connectionString)
	{
        Configuration = new DeviceConfig(connectionString);
	}
}
