using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Contexts;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ZeniApp.Mvvm.Views;

namespace ZeniApp.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly ZeniAppDbContext _context;
	private readonly IotHubManager _iotHubManager;

	public MainViewModel(ZeniAppDbContext context, IotHubManager iotHubManager)
	{
		_context = context;
		_iotHubManager = iotHubManager;
		CheckConfigurationAsync().ConfigureAwait(false);
		
	}

	private async Task CheckConfigurationAsync()
	{
		try
		{
			if (await _context.Settings.AnyAsync())
			{
				await _iotHubManager.InitializeAsync();
				await Shell.Current.GoToAsync(nameof(OverviewPage));
			}
				
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
	}


	[RelayCommand]
	async Task GoToGetStarted()
	{
		await Shell.Current.GoToAsync(nameof(GetStartedPage));
	}
}
