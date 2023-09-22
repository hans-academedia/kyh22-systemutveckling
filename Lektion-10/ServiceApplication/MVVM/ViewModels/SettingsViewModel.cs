using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceApplication.MVVM.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
	private readonly IServiceProvider _serviceProvider;

	public SettingsViewModel(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	[ObservableProperty]
	private string? _title = "Settings";

	[ObservableProperty]
	private ObservableObject? _currentContentViewModel;

	[RelayCommand]
	private void NavigateToHome()
	{
		var mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
		mainWindowViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
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
