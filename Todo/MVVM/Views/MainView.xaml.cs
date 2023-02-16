using Tasker.MVVM.ViewModels;

namespace Todo.MVVM.Views;

public partial class MainView : ContentPage
{
	MainViewModel mainViewModel = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;

	}

	private void ChkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		mainViewModel.UpdateData();

	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var taskView = new NewTaskView
		{
			BindingContext = new NewTaskViewModel
			{
				Tasks = mainViewModel.Tasks,
				Categories = mainViewModel.Categories
			}
		};

		await Navigation.PushAsync(taskView);
	}
}