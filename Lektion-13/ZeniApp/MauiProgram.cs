using CommunityToolkit.Maui;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});


			builder.Services.AddDbContext<ZeniAppDbContext>(x => x.UseSqlite($"Data Source={DatabasePathFinder.GetPath()}", x => x.MigrationsAssembly(nameof(DataAccess))));

			return builder.Build();
		}
	}
}