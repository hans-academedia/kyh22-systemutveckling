using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace ServiceApplication.MVVM.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
	[ObservableProperty]
	private string? _title = "Settings";

	[ObservableProperty]
	private ObservableObject? _currentContentViewModel;

	[RelayCommand]
	private void NavigateToHome()
	{

	}

	[RelayCommand]
	private void ShowAddDevice()
	{

	}

	[RelayCommand]
	private void ShowDeviceList()
	{

	}

	[RelayCommand]
	private void ShowConfiguration()
	{

	}

	[RelayCommand]
	private void ExitApplication()
	{
		Environment.Exit(0);
	}
}
