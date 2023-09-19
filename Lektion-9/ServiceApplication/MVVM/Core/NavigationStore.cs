namespace ServiceApplication.MVVM.Core;

public class NavigationStore : ObservableObject
{
	private ObservableObject? _currentViewModel;
	public ObservableObject? CurrentViewModel 
	{ 
		get => _currentViewModel; 
		set => SetValue(ref _currentViewModel, value); 
	}

	public void NavigateTo(ObservableObject? viewModel)
	{
		CurrentViewModel = viewModel;
	}
}
