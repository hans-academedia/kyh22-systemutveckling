using ZeniApp.Mvvm.Views;

namespace ZeniApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(OverviewPage), typeof(OverviewPage));
			Routing.RegisterRoute(nameof(GetStartedPage), typeof(GetStartedPage));
		}
	}
}