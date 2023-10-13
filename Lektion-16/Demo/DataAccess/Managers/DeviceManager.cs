using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

namespace DataAccess.Managers;

public class DeviceManager
{
    private string _connectionString = string.Empty;
    private DeviceClient _client = null!;

    public async Task InitializeAsync(string connectionString, TwinCollection twinCollection)
    {
        _connectionString = connectionString;
        _client = DeviceClient.CreateFromConnectionString(_connectionString);

        await UpdateReportedPropertiesAsync(twinCollection);
    }

    public async Task UpdateReportedPropertiesAsync(TwinCollection twinCollection)
    {
        if (twinCollection != null)
            await _client.UpdateReportedPropertiesAsync(twinCollection);
    }

    public async Task ReadDesiredPropertiesAsync()
    {
        var twin = await _client.GetTwinAsync();
        if (twin != null)
        {
            try
            {
                var location = twin.Properties.Desired["location"].ToString();
                Console.WriteLine("Location: " + location);
            }
            catch { }

        }
    }
}
