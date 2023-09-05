using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;

DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(
    "HostName=kyh-iothub.azure-devices.net;DeviceId=simple_device;SharedAccessKey=rHAxpwcg0Y88xH0wUSRLT6PgvmJNB+/DdkoSiQmUQPg=", 
    TransportType.Mqtt);

var data = new
{
    Message = "Mitt meddelande",
    Created = DateTime.Now
};

await SendTelemetryAsync(JsonConvert.SerializeObject(data));


// Send D2C Messages to Azure IoT Hub
async Task SendTelemetryAsync(string payloadAsJson)
{
    while (true)
    {
        var message = new Message(Encoding.UTF8.GetBytes(payloadAsJson));
        await deviceClient.SendEventAsync(message);

        Console.WriteLine($"Message sent at {DateTime.Now} with payload {payloadAsJson}");
        await Task.Delay(5000);
    }
}