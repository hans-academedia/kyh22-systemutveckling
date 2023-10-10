using DataAccess.Contexts;
using Microsoft.Azure.Devices.Client;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess.Services;

public class DeviceManager
{
    private DeviceClient _deviceClient = null!;
    private DataContext _context;

    public DeviceManager(DataContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync(string apiUrl)
    {
        var config = await _context.Configurations.FirstOrDefaultAsync();
        if (config != null)
        {
            if (string.IsNullOrEmpty(config.DeviceConnectionString))
            {
                using var http = new HttpClient();
                var result = await http.PostAsync(apiUrl,
                    new StringContent(JsonConvert.SerializeObject(new { deviceId = config.DeviceId })));

                if (result.IsSuccessStatusCode)
                {
                    var connectionString = await result.Content.ReadAsStringAsync();
                    config.DeviceConnectionString = connectionString;
                    _context.Configurations.Update(config);
                    await _context.SaveChangesAsync();
                }
            }

            _deviceClient = DeviceClient.CreateFromConnectionString(config.DeviceConnectionString);
        }
    }
}
