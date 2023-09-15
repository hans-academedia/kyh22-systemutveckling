using Newtonsoft.Json;
using ServiceApplication.MVVM.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ServiceApplication.MVVM.Controls;

public partial class WeatherControl : UserControl, INotifyPropertyChanged
{

    private string? _temperature;
    private string? _condition;

    public string? Temperature
    {
        get { return _temperature; }
        set { _temperature = value; OnPropertyChanged(nameof(Temperature)); }
    }

    public string? Condition
    {
        get { return _condition; }
        set { _condition = value; OnPropertyChanged(nameof(Condition)); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual  void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



    public WeatherControl()
    {
        InitializeComponent();
        DataContext = this;

        DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMinutes(15)
        };
        timer.Tick += async (s, e) => await GetWeatherAsync();
        Loaded += async (s, e) => await GetWeatherAsync();
        timer.Start();
    }

    private async Task GetWeatherAsync()
    {
        using HttpClient http = new HttpClient();
        try
        {
            var data = JsonConvert.DeserializeObject<dynamic>(await http.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=59.1875&lon=18.1232&appid=b4a3119e986341f8f3a4d159c5787679"));
            Temperature = (data!.main.temp - 273.15).ToString("#,##0.0");

            switch (data!.weather[0].description.ToString())
            {
                case "clear sky":
                    Condition = "\ue28f";
                    break;
                case "few clouds":
                    Condition = "\uf6c4";
                    break;
                case "overcast clouds":
                    Condition = "\uf744";
                    break;
                case "scattered clouds":
                    Condition = "\uf0c2";
                    break;
                case "broken clouds":
                    Condition = "\uf744";
                    break;
                case "shower rain":
                    Condition = "\uf738";
                    break;
                case "rain":
                    Condition = "\uf740";
                    break;
                case "thunderstorm":
                    Condition = "\uf76c";
                    break;
                case "snow":
                    Condition = "\uf742";
                    break;
                case "mist":
                    Condition = "\uf74e";
                    break;

                default:
                    Condition = "\ue137";
                    break;
            }

        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Failed to get weather data. Error: {ex.Message}");
            Temperature = "--";

        }
    }
}
