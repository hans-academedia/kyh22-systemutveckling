using Microsoft.Extensions.Logging;
using SmartApp.Mvvm.ViewModels;
using SmartApp.Mvvm.Views;

namespace SmartApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<HomeViewModel>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<GetStartedViewModel>();
			builder.Services.AddSingleton<GetStartedPage>();







#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}