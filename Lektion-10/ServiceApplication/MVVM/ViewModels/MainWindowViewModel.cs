using CommunityToolkit.Mvvm.ComponentModel;

namespace ServiceApplication.MVVM.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
	[ObservableProperty]
	private ObservableObject? _currentViewModel;

	public MainWindowViewModel()
	{

	}
}
