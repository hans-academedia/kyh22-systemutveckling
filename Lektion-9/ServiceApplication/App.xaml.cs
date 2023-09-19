using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceApplication.MVVM.Core;
using ServiceApplication.MVVM.ViewModels;
using System.Windows;

namespace ServiceApplication;

public partial class App : Application
{
	private static IHost? host { get; set; }

	public App()
	{
		host = Host.CreateDefaultBuilder()
			.ConfigureServices((config, services) =>
			{
				services.AddSingleton<NavigationStore>();
				services.AddSingleton<MainWindow>();
				services.AddSingleton<HomeViewModel>();
				services.AddSingleton<SettingsViewModel>();
			})
			.Build();
	}

	protected override async void OnStartup(StartupEventArgs args)
	{
		var mainWindow = host!.Services.GetRequiredService<MainWindow>();
		var navigationStore = host!.Services.GetRequiredService<NavigationStore>();
		navigationStore.CurrentViewModel = new HomeViewModel();

		await host!.StartAsync();
		mainWindow.Show();
		base.OnStartup(args);
	}
}
