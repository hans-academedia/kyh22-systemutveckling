using DataAccess.Contexts;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDevice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((config, services) =>
            {
                services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=Database.sqlite.db"));
                services.AddSingleton<DeviceManager>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
        }

        protected override async void OnStartup(StartupEventArgs args)
        {
            var mainWindow = AppHost!.Services.GetRequiredService<MainWindow>();
            var deviceManager = AppHost!.Services.GetRequiredService<DeviceManager>();
            await deviceManager.InitializeAsync("https://kyh-demo-fa.azurewebsites.net/api/RegisterDevice?code=WTnAt941_ZJToaKNGNT3KKdHYuRNoItz489FCj_Fddi4AzFu5OcvKw==");

            await AppHost!.StartAsync();
            mainWindow.Show();
            base.OnStartup(args);
        }
    }
}
