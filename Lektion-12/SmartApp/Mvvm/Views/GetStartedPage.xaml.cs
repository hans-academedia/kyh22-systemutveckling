using SmartApp.Mvvm.ViewModels;

namespace SmartApp.Mvvm.Views;

public partial class GetStartedPage : ContentPage
{
	public GetStartedPage(GetStartedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}