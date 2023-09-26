using SmartHome.MVVM.ViewModels;

namespace SmartHome.MVVM.Pages;

public partial class GetStartedPage : ContentPage
{
	public GetStartedPage(GetStartedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}