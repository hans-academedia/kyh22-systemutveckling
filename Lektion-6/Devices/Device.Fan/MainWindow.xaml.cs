using Device.Fan.Services;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Device.Fan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DeviceManager _deviceManager;
        private readonly NetworkManager _networkManager;

        public MainWindow(DeviceManager deviceManager, NetworkManager networkManager)
        {
            InitializeComponent();

            _deviceManager = deviceManager;
            _networkManager = networkManager;

            Task.WhenAll(ToggleFanStateAsync(), CheckConnectivityAsync());
        }


        private async Task ToggleFanStateAsync()
        {
            Storyboard fan = (Storyboard)this.FindResource("FanStoryboard");

            while (true)
            {
                if (_deviceManager.AllowSending())
                    fan.Begin();
                else
                    fan.Stop();

                await Task.Delay(1000);
            }
        }

        private async Task CheckConnectivityAsync()
        {
            while (true)
            {
                ConnectivityStatus.Text = await _networkManager.CheckConnectivityAsync();
                await Task.Delay(1000);
            }
        }
    }
}
