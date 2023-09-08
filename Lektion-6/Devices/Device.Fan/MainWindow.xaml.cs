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
        public MainWindow()
        {
            InitializeComponent();
            Task.WhenAll(ToggleFanStateAsync());
        }


        private async Task ToggleFanStateAsync()
        {
            Storyboard fan = (Storyboard)this.FindResource("FanStoryboard");

            while (true)
            {
                fan.Begin();
                await Task.Delay(1000);
            }
        }
    }
}
