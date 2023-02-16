using Todo.MVVM.Views;

namespace Todo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainView());
	}
}
