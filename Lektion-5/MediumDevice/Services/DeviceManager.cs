using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;

namespace MediumDevice.Services;

internal class DeviceManager
{
	public DeviceConfig Configuration { get; set; }

	public DeviceManager(string connectionString)
	{
        Configuration = new DeviceConfig(connectionString);
	}

	public async Task StartAsync()
	{
        while (true)
        {
            var data = new
            {
                Temperature = 20,
                Humidity = 44,
                Created = DateTime.Now
            };

            await SendDataAsync(JsonConvert.SerializeObject(data));
            await Task.Delay(Configuration.TelemetryInterval);
        }
    }


	private async Task SendDataAsync(string dataAsJson)
	{
		if (!string.IsNullOrEmpty(dataAsJson))
		{
			var message = new Message(Encoding.UTF8.GetBytes(dataAsJson));
			await Configuration.DeviceClient.SendEventAsync(message);
		}
	}

}
