using SmartApp.Mvvm.ViewModels;

namespace SmartApp.Mvvm.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}