using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceApplication.MVVM.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
	private readonly IServiceProvider _serviceProvider;

	public MainWindowViewModel(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
		CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
	}

	[ObservableProperty]
	private ObservableObject? _currentViewModel;

}
