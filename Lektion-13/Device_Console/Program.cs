using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

await Task.Delay(5000);

var connectionstring = string.Empty;
DeviceClient deviceClient = null!;

if (string.IsNullOrEmpty(connectionstring))
{
	using var httpClient = new HttpClient();
	var result = await httpClient.PostAsync("http://localhost:7155/api/DeviceRegistration?deviceId=test_1234", null!);
	connectionstring = await result.Content.ReadAsStringAsync();

	deviceClient = DeviceClient.CreateFromConnectionString(connectionstring, TransportType.Mqtt);
	
	var twinCollection = new TwinCollection();
	twinCollection["deviceType"] = "console";
	await deviceClient.UpdateReportedPropertiesAsync(twinCollection);

	var twin = await deviceClient.GetTwinAsync();

	Console.WriteLine("Device Connected!");
	Console.WriteLine($"{twin.Properties.Reported["deviceType"]}");
}

Console.ReadKey();