using ZeniApp.Mvvm.ViewModels;

namespace ZeniApp.Mvvm.Views;

public partial class GetStartedPage : ContentPage
{
	public GetStartedPage(GetStartedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}