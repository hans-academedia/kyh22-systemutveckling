using Iot_Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Console_Device
{
    internal class Program
    {

        public static IHost? AppHost { get; set; }

        static async Task Main(string[] args)
        {
           
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((config, services) =>
                {
                    services.AddSingleton(new DeviceManager("HostName=kyh-iothub.azure-devices.net;DeviceId=console_device;SharedAccessKey=MGm9oNl2AXU8rgMR0r3SKk3w0eq2yb32DeTy4kKRmXg="));
                })
                .Build();


            // Specifikt för konsolapplikationer
            using var scope = AppHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var deviceManager = services.GetRequiredService<DeviceManager>();

            await AppHost.StartAsync();

            Console.Clear();
            Console.WriteLine("console_device started...");
            
            await SendTelemetryDataAsync(deviceManager);

            Console.ReadKey();
        }


        private static async Task SendTelemetryDataAsync(DeviceManager deviceManager)
        {
            while(true)
            {
                if (deviceManager.CanSendData)
                {
                    var payload = new
                    {
                        Temp = 22,
                        Humi = 80,
                        Created = DateTime.Now
                    };

                    var json = JsonConvert.SerializeObject(payload);

                    if (await deviceManager.SendDataAsync(json))
                        Console.WriteLine($"Message sent successfully: {json}");

                    await Task.Delay(1000);
                }
            }
        }
    }
}