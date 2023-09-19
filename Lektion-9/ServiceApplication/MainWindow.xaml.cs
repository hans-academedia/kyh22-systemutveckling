using ServiceApplication.MVVM.Core;
using System.Windows;

namespace ServiceApplication;

public partial class MainWindow : Window
{
	public MainWindow(NavigationStore navigationStore)
	{
		InitializeComponent();
		DataContext = navigationStore;
	}
}
