using Iot_Shared.Services;
using Microsoft.Extensions.Logging;

namespace Maui_Device
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton(new DeviceManager("HostName=kyh-iothub.azure-devices.net;DeviceId=maui_device;SharedAccessKey=P8UEID2e7sn3LQJCcQnPB8WYs1/SNV8lJSuNzz2GCxw="));
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}