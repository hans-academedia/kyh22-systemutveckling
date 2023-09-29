using SmartApp.Mvvm.Views;

namespace SmartApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
			Routing.RegisterRoute(nameof(GetStartedPage), typeof(GetStartedPage));
		}
	}
}