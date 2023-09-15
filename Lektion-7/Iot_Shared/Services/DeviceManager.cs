using Iot_Shared.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Iot_Shared.Services;

public class DeviceManager
{
    private DeviceClient _deviceClient = null!;
    private string _connectionString = null!;
    public bool CanSendData { get; private set; } = true;

    public DeviceManager(string deviceConnectionString)
    {
        _connectionString = deviceConnectionString;
        _deviceClient = DeviceClient.CreateFromConnectionString(_connectionString);
        Task.FromResult(_deviceClient.SetMethodDefaultHandlerAsync(MethodDefaultHandlerCallback, null));
    }

    private async Task<MethodResponse> MethodDefaultHandlerCallback(MethodRequest req, object context)
    {
        var res = new MethodDataResponse();

        try
        {
            res.Message = $"Method: {req.Name} executed successfully.";

            switch (req.Name.ToLower())
            {
                case "start":
                    CanSendData = true;
                    break;

                case "stop":
                    CanSendData = false;
                    break;

                default:
                    res.Message = $"Method: {req.Name} could not be found.";
                    return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 404);
            }

            await Task.Delay(10);
            return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 200);
        } 
        catch (Exception ex) 
        {
            res.Message = $"Error: {ex.Message}";
            return new MethodResponse(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res)), 400);
        }
    }

    public async Task<bool> SendDataAsync(string payload)
    {
        try
        {
            var message = new Message(Encoding.UTF8.GetBytes(payload));
            await _deviceClient.SendEventAsync(message);
            await Task.Delay(10);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

}
