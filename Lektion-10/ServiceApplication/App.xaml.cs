using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceApplication.MVVM.ViewModels;
using ServiceApplication.Services;
using System.Net.Http;
using System.Windows;

namespace ServiceApplication;

public partial class App : Application
{
	private static IHost? AppHost { get; set; }

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices(services =>
			{
				services.AddTransient<HttpClient>();
				services.AddSingleton<DateAndTimeService>();
				services.AddSingleton<WeatherService>();

				services.AddSingleton<HomeViewModel>();
				services.AddSingleton<SettingsViewModel>();
				services.AddSingleton<MainWindowViewModel>();
				services.AddSingleton<MainWindow>();
			})
			.Build();
	}

	protected override async void OnStartup(StartupEventArgs e)
	{
		await AppHost!.StartAsync();

		var mainWindow = AppHost!.Services.GetRequiredService<MainWindow>();
		mainWindow.Show();

		base.OnStartup(e);
	}
}
