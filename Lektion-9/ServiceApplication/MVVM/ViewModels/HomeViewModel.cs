using ServiceApplication.MVVM.Core;

namespace ServiceApplication.MVVM.ViewModels;

public class HomeViewModel : ObservableObject
{
	private string? _currentTime;
	public string? CurrentTime {  get => _currentTime; set => SetValue(ref _currentTime, value); }

	private string? _currentDate;
	public string? CurrentDate { get => _currentDate; set => SetValue(ref _currentDate, value); }

}
