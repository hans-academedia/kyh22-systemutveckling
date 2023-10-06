using DataAccess.Devices.Models;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;

namespace DataAccess.Devices.Services;

public class DeviceManager
{
    public bool IsConfigured { get; private set; }
    public event Action? IsConfiguredChanged;
    private DeviceClient? _deviceClient;

    public DeviceManager()
	{

	}
    public DeviceManager(string deviceId, string url)
    {
        Task.Run(() => InitializeAsync(deviceId, url));
    }
    public async Task InitializeAsync(string deviceId, string url)
    {
        var deviceItem = new DeviceItem { DeviceId = deviceId };
     
        using var http = new HttpClient();
        var result = await http.PostAsync(url, new StringContent(JsonConvert.SerializeObject(deviceItem)));
        if (result.IsSuccessStatusCode)
        {
            var connectionString = await result.Content.ReadAsStringAsync();
            FileHandler.SaveToFile(@$"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\config_{deviceItem.DeviceId}.txt", connectionString);
            
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);
            IsConfigured = true;

            IsConfiguredChanged?.Invoke();
        } 
        else
        {
            IsConfigured = false;
        }
    }

    public async Task UpdateTwinPropsAsync(TwinCollection twinCollection)
    {
        if (IsConfigured)
            await _deviceClient!.UpdateReportedPropertiesAsync(twinCollection);
    }

    public async Task SetDirectMethodAsync(string methodName, MethodCallback methodCallback)
    {
        if (IsConfigured)
            await _deviceClient!.SetMethodHandlerAsync(methodName, methodCallback, null!);
    }
}
