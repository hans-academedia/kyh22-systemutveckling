using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;

namespace AdvancedDevice.Services;

internal class DeviceManager
{
    public DeviceConfiguration Configuration { get; set; }

    public DeviceManager(string connectionString)
    {
        Configuration = new DeviceConfiguration(connectionString);
        Configuration.DeviceClient.SetMethodDefaultHandlerAsync(DirectMethodCallback, null).Wait();
    }

    public void Start()
    {
        Task.WhenAll(
            SetTelemetryIntervalAsync(),
            NetworkManager.CheckConnectivityAsync(),
            SendTelemetryAsync()
        );
    }

    private async Task SetTelemetryIntervalAsync()
    {
        var _telemetryInterval = await DeviceTwinManager
            .GetDesiredTwinPropertyAsync(Configuration.DeviceClient, "telemetryInterval");

        if (_telemetryInterval != null)
            Configuration.TelemetryInterval = int.Parse(_telemetryInterval.ToString()!);

        await DeviceTwinManager
            .UpdateReportedTwinPropertyAsync(Configuration.DeviceClient, "telemetryInterval", Configuration.TelemetryInterval);
    }


    private async Task SendTelemetryAsync()
    {
        while (true)
        {
            if(Configuration.AllowSending)
            {
                var data = new
                {
                    Message = "Hejsan",
                    Created = DateTime.Now
                };

                await SendDataAsync(JsonConvert.SerializeObject(data));
                await Task.Delay(Configuration.TelemetryInterval);
            }
        }
    }


    private async Task SendDataAsync(string dataAsJson)
    {
        if (!string.IsNullOrEmpty(dataAsJson))
        {
            var message = new Message(Encoding.UTF8.GetBytes(dataAsJson));
            await Configuration.DeviceClient.SendEventAsync(message);
            Console.WriteLine($"Message sent at {DateTime.Now} with data {dataAsJson}");        
        }
    }

    private async Task<MethodResponse> DirectMethodCallback(MethodRequest methodRequest, object userContext)
    {
        var response = new { message = $"Executed Direct Method: {methodRequest.Name}" };

        switch (methodRequest.Name.ToLower())
        {
            case "start":
                Configuration.AllowSending = true;
                await DeviceTwinManager.UpdateReportedTwinPropertyAsync(Configuration.DeviceClient, "allowSending", Configuration.AllowSending);
                return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), 200);

            case "stop":
                Configuration.AllowSending = false;
                await DeviceTwinManager.UpdateReportedTwinPropertyAsync(Configuration.DeviceClient, "allowSending", Configuration.AllowSending);
                return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)), 200);
        }

        return new MethodResponse(400);
    }

}
