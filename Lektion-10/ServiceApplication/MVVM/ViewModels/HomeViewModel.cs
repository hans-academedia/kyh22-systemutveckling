using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ServiceApplication.MVVM.ViewModels;

public partial class HomeViewModel : ObservableObject
{
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

	}
}
