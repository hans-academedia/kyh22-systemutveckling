using DataAccess.Managers;
using Microsoft.Azure.Devices.Shared;

var twinCollection = new TwinCollection();
twinCollection["deviceType"] = "themometor";


var deviceManager = new DeviceManager();
await deviceManager.InitializeAsync("HostName=kyh-iothub.azure-devices.net;DeviceId=themometor_device;SharedAccessKey=9Hxhd9swy5tJIznTqB9giYjum6QfyuEj6AIoTNk1/e8=", twinCollection);
await deviceManager.ReadDesiredPropertiesAsync();


Console.ReadKey();