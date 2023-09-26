using SmartHome.MVVM.Pages;

namespace SmartHome
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
			Routing.RegisterRoute(nameof(AllDevicesPage), typeof(AllDevicesPage));
			Routing.RegisterRoute(nameof(GetStartedPage), typeof(GetStartedPage));
		}
	}
}