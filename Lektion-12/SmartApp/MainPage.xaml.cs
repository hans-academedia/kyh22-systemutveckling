using SmartApp.Mvvm.ViewModels;

namespace SmartApp
{
	public partial class MainPage : ContentPage
	{

		public MainPage(MainViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

	}
}