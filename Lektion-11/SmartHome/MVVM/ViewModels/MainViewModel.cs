using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartHome.MVVM.Pages;

namespace SmartHome.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
	[RelayCommand]
	async Task GoToSettings() => await Shell.Current.GoToAsync(nameof(SettingsPage));

	[RelayCommand]
	async Task GoToAllDevices() => await Shell.Current.GoToAsync(nameof(AllDevicesPage));

	[RelayCommand]
	void ToggleState(object obj)
	{
		// send direct method message to deviceId
	}


	[ObservableProperty]
	private bool isConfigured;

	public async Task CheckConfiguration()
	{
		if (!IsConfigured)
			await Shell.Current.GoToAsync(nameof(GetStartedPage));
	}
}
