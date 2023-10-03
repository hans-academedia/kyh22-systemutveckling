using Camera.MAUI;
using CommunityToolkit.Maui;
using DataAccess.Contexts;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZeniApp.Mvvm.ViewModels;
using ZeniApp.Mvvm.Views;
using ZeniApp.Resources.Helpers;

namespace ZeniApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.UseMauiCameraView()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			builder.Services.AddDbContext<ZeniAppDbContext>(x => x.UseSqlite($"Data Source={DatabasePathFinder.GetPath()}", x => x.MigrationsAssembly(nameof(DataAccess))));
			builder.Services.AddSingleton<IotHubManager>();


			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<MainPage>();

			builder.Services.AddSingleton<GetStartedViewModel>();
			builder.Services.AddSingleton<GetStartedPage>();

			builder.Services.AddSingleton<OverviewViewModel>();
			builder.Services.AddSingleton<OverviewPage>();


			return builder.Build();
		}
	}
}