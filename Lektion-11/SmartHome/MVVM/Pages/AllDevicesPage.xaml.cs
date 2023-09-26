using SmartHome.MVVM.ViewModels;

namespace SmartHome.MVVM.Pages;

public partial class AllDevicesPage : ContentPage
{
	public AllDevicesPage(AllDevicesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}