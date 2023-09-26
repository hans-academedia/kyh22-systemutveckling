using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SmartHome.MVVM.Pages;
using SmartHome.MVVM.ViewModels;

namespace SmartHome
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
					fonts.AddFont("fa-thin-100.ttf", "FontAwesomeThin");
					fonts.AddFont("fa-light-300.ttf", "FontAwesomeLight");
					fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
					fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
				});

			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<SettingsViewModel>();
			builder.Services.AddSingleton<SettingsPage>();
			builder.Services.AddSingleton<AllDevicesViewModel>();
			builder.Services.AddSingleton<AllDevicesPage>();
			builder.Services.AddSingleton<GetStartedViewModel>();
			builder.Services.AddSingleton<GetStartedPage>();


#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}