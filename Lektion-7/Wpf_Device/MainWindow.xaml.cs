using Iot_Shared.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Device
{
    public partial class MainWindow : Window
    {
        private readonly DeviceManager _deviceManager;

        public MainWindow(DeviceManager deviceManager)
        {
            InitializeComponent();
            _deviceManager = deviceManager;
            Task.FromResult(SendTelemetryDataAsync());
        }

        private async Task SendTelemetryDataAsync()
        {
            while(true)
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
