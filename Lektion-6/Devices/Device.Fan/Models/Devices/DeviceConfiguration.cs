namespace Device.Fan.Models.Devices;

public class DeviceConfiguration
{
    private readonly string _connectionString;

    public DeviceConfiguration(string connectionString)
    {
        _connectionString = connectionString;
    }

    public string DeviceId => _connectionString.Split(";")[1].Split("=")[1];
    public string ConnectionString => _connectionString;
    public bool AllowSending { get; set; } = false;
    public int TelemetryInterval { get; set; } = 10000;

}
