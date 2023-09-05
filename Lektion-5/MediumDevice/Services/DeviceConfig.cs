using Microsoft.Azure.Devices.Client;

namespace MediumDevice.Services;

internal class DeviceConfig
{
    public DeviceConfig(string connectionString)
    {
        ConnectionString = connectionString;
        Initialize();
    }

    public string ConnectionString { get; private set; } = null!;
    public DeviceClient DeviceClient { get; private set; } = null!;
    public int TelemetryInterval { get; set; } = 10000;

    public string DeviceId { get; private set; } = null!;
    public string? DeviceName { get; set; }
    public string? DeviceType { get; set; }
    public string? Location { get; set; }

    public void Initialize()
    {
        if (ConnectionString != null)
        {
            DeviceId = ConnectionString.Split(";")[1].Split("=")[1];
            DeviceClient = DeviceClient.CreateFromConnectionString(ConnectionString, TransportType.Mqtt);
        }           
    }
}
