using ServiceApplication.MVVM.Core;
using ServiceApplication.Services;
using System.Windows.Input;

namespace ServiceApplication.MVVM.ViewModels;

public class SettingsViewModel : ObservableObject
{
	private readonly NavigationStore _navigationStore;
	private readonly DateTimeService _dateTimeService;

	public SettingsViewModel(NavigationStore navigationStore, DateTimeService dateTimeService)
	{
		_navigationStore = navigationStore;
		_dateTimeService = dateTimeService;
	}

	// Navigation
	public ICommand NavigateToHomeCommand =>
		new RelayCommand(() => _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _dateTimeService));

	public ICommand CloseApplicationCommand =>
		new RelayCommand(() => ApplicationService.CloseApplication());


	private string? _title = "Settings";
	public string? Title { get => _title; set => SetValue(ref _title, value); }




}
