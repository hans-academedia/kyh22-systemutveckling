using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ServiceApplication.Services;
using System;
using System.Threading.Tasks;

namespace ServiceApplication.MVVM.ViewModels;

public partial class HomeViewModel : ObservableObject
{
	private readonly IServiceProvider _serviceProvider;
	private readonly DateAndTimeService _dateAndTimeService;
	private readonly WeatherService _weatherService;

	public HomeViewModel(IServiceProvider serviceProvider, DateAndTimeService dateAndTimeService, WeatherService weatherService)
	{
		_serviceProvider = serviceProvider;
		_dateAndTimeService = dateAndTimeService;
		_weatherService = weatherService;

		UpdateDateAndTime();
		UpdateWeather();
	}

	[ObservableProperty]
	private string? _title = "Home";

	[ObservableProperty]
	private string? _currentTime = "--:--";

	[ObservableProperty]
	private string? _currentDate;

	[ObservableProperty]
	private string? _currentWeatherCondition = "\ue137";

	[ObservableProperty]
	private string? _currentTemperature = "--";

	[ObservableProperty]
	private string? _currentTemperatureUnit = "°C";

	[RelayCommand]
	private void NavigateToSettings()
	{
		var mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
		mainWindowViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<SettingsViewModel>();
	}


	private void UpdateDateAndTime()
	{

		_dateAndTimeService.TimeUpdated += () =>
		{
			CurrentDate = _dateAndTimeService.CurrentDate;
			CurrentTime = _dateAndTimeService.CurrentTime;
		};
	}

	private void UpdateWeather()
	{

		_weatherService.WeatherUpdated += () =>
		{
			CurrentWeatherCondition = _weatherService.CurrentWeatherCondition;
			CurrentTemperature = _weatherService.CurrentTemperature;
		};
	}
}
