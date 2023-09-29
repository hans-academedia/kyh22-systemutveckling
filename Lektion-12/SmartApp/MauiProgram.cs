using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartApp.Mvvm.ViewModels;
using SmartApp.Mvvm.Views;
using SmartApp.Services;

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
					fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
				});

			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<HomeViewModel>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<GetStartedViewModel>();
			builder.Services.AddSingleton<GetStartedPage>();
			builder.Services.AddSingleton<DeviceManager>();
			builder.Services.AddDbContext<DataContext>(x => x.UseSqlite($"Data Source={DatabasePathFinder.GetPath()}"));







#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}