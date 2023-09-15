using ServiceApplication.MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ServiceApplication;

public partial class MainWindow : Window
{
    public ObservableCollection<DeviceItem> Devices { get; set; } = new ObservableCollection<DeviceItem>()
    {
        new DeviceItem { DeviceId = "1", DeviceType = "light", Placement = "Kitchen", IsActive = true },
        new DeviceItem { DeviceId = "2", DeviceType = "ledstrip", Placement = "Livingroom", IsActive = false },
        new DeviceItem { DeviceId = "3", DeviceType = "fan", Placement = "Bedroom", IsActive = false }
    };

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        DeviceList.ItemsSource = Devices;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            this.DragMove();
    }
}
