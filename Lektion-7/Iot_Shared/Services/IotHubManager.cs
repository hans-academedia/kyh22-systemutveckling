﻿using Azure.Messaging.EventHubs.Consumer;
using Iot_Shared.Models;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Iot_Shared.Services;

public class IotHubManager
{
    private RegistryManager _registryManager;
    private ServiceClient _serviceClient;
    private EventHubConsumerClient _consumerClient;

    public IotHubManager(IotHubManagerOptions options)
    {
        _registryManager = RegistryManager.CreateFromConnectionString(options.IotHubConnectionString);
        _serviceClient = ServiceClient.CreateFromConnectionString(options.IotHubConnectionString);
        _consumerClient = new EventHubConsumerClient(options.ConsumerGroup, options.EventHubEndpoint);

        
    }









    public async Task<CloudToDeviceMethodResult> SendMethodAsync(MethodDataRequest req)
    {
        try
        {
            var cloudMethod = new CloudToDeviceMethod(req.MethodName)
            {
                ConnectionTimeout = new TimeSpan(req.ResponseTimeout)
            };

            if (req.Payload != null)
                cloudMethod.SetPayloadJson(JsonConvert.SerializeObject(req.Payload));

            var result = await _serviceClient.InvokeDeviceMethodAsync(req.DeviceId, cloudMethod);
            if (result != null)
                return result;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<string>> GetDevicesAsJsonAsync(string sqlQuery = "select * from devices")
    {
        try
        {
            var devices = new List<string>();
            var result = _registryManager.CreateQuery(sqlQuery);
            if (result.HasMoreResults)
                foreach(var device in await result.GetNextAsJsonAsync())
                    devices.Add(device);

            return devices;
        }
        catch (Exception ex) { Debug.WriteLine($"{ex.Message}"); }
        return null!;
    }

    public async Task<IEnumerable<Twin>> GetDevicesAsTwinAsync(string sqlQuery = "select * from devices")
    {
        try
        {
            var devices = new List<Twin>();
            var result = _registryManager.CreateQuery(sqlQuery);
            if (result.HasMoreResults)
                foreach (var device in await result.GetNextAsTwinAsync())
                    devices.Add(device);

            return devices;
        }
        catch (Exception ex) { Debug.WriteLine($"{ex.Message}"); }
        return null!;
    }
}
