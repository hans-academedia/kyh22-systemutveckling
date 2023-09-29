using CommunityToolkit.Mvvm.ComponentModel;
using SmartApp.Mvvm.Models;

namespace SmartApp.Mvvm.ViewModels;

public partial class DeviceItemViewModel : ObservableObject
{
	private DeviceItem _deviceItem;

	public DeviceItemViewModel(DeviceItem deviceItem)
	{
		_deviceItem = deviceItem;
		Location = deviceItem.Location ?? "";
		IsActive = deviceItem.IsActive;
		Icon = SetDeviceIcon();
	}


	public string DeviceId => _deviceItem.DeviceId ?? "";
	public string DeviceType => _deviceItem.DeviceType ?? "";
	public string Vendor => _deviceItem.Vendor ?? "";

	[ObservableProperty]
	string location;

	[ObservableProperty]
	bool isActive;

	[ObservableProperty]
	string icon;


	private string SetDeviceIcon()
	{
		return DeviceType.ToLower() switch
		{
			"light" => "\uf0eb",
			_ => "\uf2db",
		};
	}
}
