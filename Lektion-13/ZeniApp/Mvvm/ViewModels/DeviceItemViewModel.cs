using DataAccess.Models;

namespace ZeniApp.Mvvm.ViewModels;

public class DeviceItemViewModel
{
	private DeviceItem _deviceItem;

	public DeviceItemViewModel(DeviceItem deviceItem)
	{
		_deviceItem = deviceItem;
	}
}
