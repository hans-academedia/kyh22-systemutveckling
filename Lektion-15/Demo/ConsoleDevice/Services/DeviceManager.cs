using ConsoleDevice.Contexts;
using Microsoft.Azure.Devices.Client;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ConsoleDevice.Services;

internal class DeviceManager
{
    private readonly string _url = "https://kyh-demo-fa.azurewebsites.net/api/RegisterDevice?code=WTnAt941_ZJToaKNGNT3KKdHYuRNoItz489FCj_Fddi4AzFu5OcvKw==";
    private DeviceClient _deviceClient = null!;
    private DataContext _context;

    public DeviceManager()
    {

    }

    public DeviceManager(DataContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        var config = await _context.Configuration.FirstOrDefaultAsync();
        if (config != null)
        {
            if(string.IsNullOrEmpty(config.ConnectionString)) 
            { 
                using var http = new HttpClient();
                var result = await http.PostAsync(_url, 
                    new StringContent(JsonConvert.SerializeObject(new { deviceId = config.DeviceId})));

                if (result.IsSuccessStatusCode)
                {
                    var connectionString = await result.Content.ReadAsStringAsync();
                    config.ConnectionString = connectionString;
                    _context.Configuration.Update(config);
                    await _context.SaveChangesAsync();
                }
            }

            _deviceClient = DeviceClient.CreateFromConnectionString(config.ConnectionString);
        }
    }
}
