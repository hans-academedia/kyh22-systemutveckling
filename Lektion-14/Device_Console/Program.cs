using DataAccess.Devices.Services;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using System.Runtime.CompilerServices;

var macAddress = "44-2F-36-2F-D0-97";
var twinCollection = new TwinCollection();
twinCollection["deviceType"] = "console";
twinCollection["location"] = "virtual";

var deviceManager = new DeviceManager(macAddress, "https://kyh-fa.azurewebsites.net/api/devices?code=izP9Ttp24_oCJ65vzrYAZiidsNXLPMVi2ZjBoG--ArCEAzFulzfHyg==");

deviceManager.IsConfiguredChanged += async () => await OnConfiguredAsync();

async Task OnConfiguredAsync()
{
    if (deviceManager!.IsConfigured)
    {
        Console.WriteLine("Is Configured");
        await deviceManager.UpdateTwinPropsAsync(twinCollection);
        Console.WriteLine("Device Twin Updated");

        await deviceManager.SetDirectMethodAsync("start", StartMethod);
        await deviceManager.SetDirectMethodAsync("stop", StopMethod);
        Console.WriteLine("Direct Method(s) Registered");
    }
}

async Task<MethodResponse> StartMethod(MethodRequest methodRequest, object userContext)
{
    Console.WriteLine($"{methodRequest.Name} triggered.");

    if (methodRequest.Name.ToLower() == "start")
        return new MethodResponse(200);

    return new MethodResponse(404);
}

async Task<MethodResponse> StopMethod(MethodRequest methodRequest, object userContext)
{
    Console.WriteLine($"{methodRequest.Name} triggered.");

    if (methodRequest.Name.ToLower() == "stop")
        return new MethodResponse(200);

    return new MethodResponse(404);
}

Console.ReadKey();