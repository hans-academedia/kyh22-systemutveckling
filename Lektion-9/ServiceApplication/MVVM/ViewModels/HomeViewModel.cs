using ServiceApplication.MVVM.Core;
using System.Windows.Input;

namespace ServiceApplication.MVVM.ViewModels;

public class HomeViewModel : ObservableObject
{
	private readonly NavigationStore _navigationStore;

	public HomeViewModel(NavigationStore navigationStore)
	{
		_navigationStore = navigationStore;
	}

	// Navigation
	public ICommand NavigateToSettingsCommand => 
		new RelayCommand(() => _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore));


	private string? _currentTime;
	public string? CurrentTime { get => _currentTime; set => SetValue(ref _currentTime, value); }

	private string? _currentDate;
	public string? CurrentDate { get => _currentDate; set => SetValue(ref _currentDate, value); }

}
