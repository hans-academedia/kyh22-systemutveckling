using ZeniApp.Mvvm.ViewModels;

namespace ZeniApp
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