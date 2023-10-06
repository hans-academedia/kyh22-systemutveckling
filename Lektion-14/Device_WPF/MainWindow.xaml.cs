using DataAccess.Devices.Services;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Device_WPF;

public partial class MainWindow : Window
{
    private readonly DeviceManager _deviceManager;
    private TwinCollection twinCollection = new TwinCollection();
    private string statusText = string.Empty;


    public MainWindow()
    {
        InitializeComponent();

        _deviceManager = new DeviceManager("D0-92-75-9E-24-F9", "https://kyh-fa.azurewebsites.net/api/devices?code=izP9Ttp24_oCJ65vzrYAZiidsNXLPMVi2ZjBoG--ArCEAzFulzfHyg==");
        twinCollection["deviceType"] = "wpf";
        twinCollection["location"] = "virtual";

        _deviceManager.IsConfiguredChanged += async () => await OnConfiguredAsync();
    }

    private void UpdateStatus(string message) => Application.Current.Dispatcher.Invoke(() => StatusActivity.Text = message);

    private async Task OnConfiguredAsync()
    {
        if (_deviceManager!.IsConfigured)
        {
            UpdateStatus("Is Configured");

            await _deviceManager.UpdateTwinPropsAsync(twinCollection);
            UpdateStatus("Device Twin Updated");
            
            await _deviceManager.SetDirectMethodAsync("start", StartMethod);
            await _deviceManager.SetDirectMethodAsync("stop", StopMethod);
            UpdateStatus("Direct Method(s) Registered");

        }
    }

    private async Task<MethodResponse> StartMethod(MethodRequest methodRequest, object userContext)
    {
        UpdateStatus($"{methodRequest.Name} triggered.");

        if (methodRequest.Name.ToLower() == "start")
        {
            var twinCollection = new TwinCollection();
            twinCollection["state"] = true;

            await _deviceManager.UpdateTwinPropsAsync(twinCollection);
            return new MethodResponse(200);
        }
            

        return new MethodResponse(404);
    }

    private async Task<MethodResponse> StopMethod(MethodRequest methodRequest, object userContext)
    {
        UpdateStatus($"{methodRequest.Name} triggered.");

        if (methodRequest.Name.ToLower() == "stop")
        {
            var twinCollection = new TwinCollection();
            twinCollection["state"] = false;

            await _deviceManager.UpdateTwinPropsAsync(twinCollection);
            return new MethodResponse(200);
        }

        return new MethodResponse(404);
    }
}
