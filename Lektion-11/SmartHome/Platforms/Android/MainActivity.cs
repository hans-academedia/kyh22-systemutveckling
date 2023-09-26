using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SmartHome
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
	public class MainActivity : MauiAppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#333333"));
			}
		}
	}
}