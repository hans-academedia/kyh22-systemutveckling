using Iot_Shared.Models;
using Iot_Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Service
{
    public partial class App : Application
    {
        public IHost? AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((config, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton(new IotHubManager(new IotHubManagerOptions
                    {
                        IotHubConnectionString = "HostName=kyh-iothub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=M/vLVpxoLM7Blwqdsc8YxXaW2A7rQRLjzAIoTFa78jI=",
                        EventHubEndpoint = "Endpoint=sb://ihsuprodamres027dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=M/vLVpxoLM7Blwqdsc8YxXaW2A7rQRLjzAIoTFa78jI=;EntityPath=iothub-ehub-kyh-iothub-25235613-13f1cd2256",
                        EventHubName = "iothub-ehub-kyh-iothub-25235613-13f1cd2256",
                        ConsumerGroup = "serviceapplication"
                    }));
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
