using AdvancedDevice.Services;

var device = new DeviceManager("HostName=kyh-iothub.azure-devices.net;DeviceId=advanced_device;SharedAccessKey=8MdPM5InpT7SsGkw0LpPxo4itL7MutntvaVQEihAAaM=");
device.Start();

Console.WriteLine("Press [Enter] to close application. \n");
Console.ReadKey();


