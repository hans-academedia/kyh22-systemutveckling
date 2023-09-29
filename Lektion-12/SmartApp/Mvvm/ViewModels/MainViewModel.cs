using CommunityToolkit.Mvvm.ComponentModel;
using SmartApp.Mvvm.Models;
using SmartApp.Mvvm.Views;
using System.Collections.ObjectModel;

namespace SmartApp.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty]
	bool isConfigured;

	[ObservableProperty]
	ObservableCollection<DeviceItem> devices;



	public MainViewModel()
	{
		IsConfigured = true;

		if (!IsConfigured)
		{
			Task.Run(() => Shell.Current.GoToAsync(nameof(GetStartedPage)));
		}

		Devices = new ObservableCollection<DeviceItem>()
		{
			new DeviceItem { DeviceId = "dev-1", DeviceType = "demo", IsActive = true, Location = "unkown" , Vendor = "Hans" },
			new DeviceItem { DeviceId = "dev-2", DeviceType = "demo", IsActive = false, Location = "unkown" , Vendor = "Hans" },
			new DeviceItem { DeviceId = "dev-3", DeviceType = "demo", IsActive = true, Location = "unkown" , Vendor = "Hans" }
		};
	}
}
