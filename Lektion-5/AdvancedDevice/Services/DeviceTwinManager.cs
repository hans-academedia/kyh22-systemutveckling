using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

namespace AdvancedDevice.Services;

internal class DeviceTwinManager
{
    public static async Task<object> GetDesiredTwinPropertyAsync(DeviceClient deviceClient, string key)
    {
        try
        {
            var twin = await deviceClient.GetTwinAsync();
            if (twin.Properties.Desired.Contains(key))
                return twin.Properties.Desired[key];
        }
        catch (Exception ex) { Console.WriteLine($"Unable to update Reported Twin. Error: {ex.Message}"); }
        return null!;
    }

    public static async Task UpdateReportedTwinPropertyAsync(DeviceClient deviceClient, string key, object value)
    {
        try
        {
            var twinProperties = new TwinCollection();
            twinProperties[key] = value;
            await deviceClient.UpdateReportedPropertiesAsync(twinProperties);
            Console.WriteLine($"Reported Twin Property: {key} updated with value: {value}");
        }
        catch (Exception ex) { Console.WriteLine($"Unable to update Reported Twin. Error: {ex.Message}"); }
    }
}
