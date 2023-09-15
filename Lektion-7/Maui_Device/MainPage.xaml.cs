using Iot_Shared.Services;
using Newtonsoft.Json;

namespace Maui_Device
{
    public partial class MainPage : ContentPage
    {
        private readonly DeviceManager _deviceManager;

        public MainPage(DeviceManager deviceManager)
        {
            InitializeComponent();

            _deviceManager = deviceManager;
            Task.FromResult(SendTelemetryDataAsync());
        }

        private async Task SendTelemetryDataAsync()
        {
            while (true)
            {
                if (_deviceManager.CanSendData)
                {
                    var payload = new
                    {
                        Temp = 22,
                        Humi = 80,
                        Created = DateTime.Now
                    };

                    var json = JsonConvert.SerializeObject(payload);

                    if (await _deviceManager.SendDataAsync(json))
                        CurrentMessageSent.Text = $"Message sent successfully: {json}";

                    await Task.Delay(1000);
                }
            }
        }

    }
}