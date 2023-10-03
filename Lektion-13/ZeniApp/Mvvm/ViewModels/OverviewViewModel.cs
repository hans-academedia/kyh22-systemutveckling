using CommunityToolkit.Mvvm.ComponentModel;
using DataAccess.Services;
using System.Collections.ObjectModel;

namespace ZeniApp.Mvvm.ViewModels;

public partial class OverviewViewModel : ObservableObject
{
	private readonly IotHubManager _iotHubManager;

	[ObservableProperty]
	ObservableCollection<DeviceItemViewModel> devicesList;
	
	public OverviewViewModel(IotHubManager iotHubManager)
	{
		_iotHubManager = iotHubManager;
		_iotHubManager.InitializeAsync().ConfigureAwait(true);

		UpdateDeviceList();
		_iotHubManager.DeviceItemListUpdated += UpdateDeviceList;
	}

	private void UpdateDeviceList()
	{
		DevicesList = new ObservableCollection<DeviceItemViewModel>(_iotHubManager.DeviceItemList
			.Select(deviceItem => new DeviceItemViewModel(deviceItem)).ToList());
	}

}
