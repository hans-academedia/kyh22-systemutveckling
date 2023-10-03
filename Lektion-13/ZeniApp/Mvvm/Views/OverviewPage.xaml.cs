using ZeniApp.Mvvm.ViewModels;

namespace ZeniApp.Mvvm.Views;

public partial class OverviewPage : ContentPage
{
	public OverviewPage(OverviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}