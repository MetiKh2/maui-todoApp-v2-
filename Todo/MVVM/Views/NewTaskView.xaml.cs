using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Todo.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
		BindingContext = new NewTaskViewModel();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var vm = BindingContext as NewTaskViewModel;

		var selectedCategory = vm.Categories.Where(x => x.isSelected == true).FirstOrDefault();

		if (selectedCategory != null)
		{
			var task = new MyTask
			{
				TaskName = vm.Task,
				CategoryId = selectedCategory.Id,
			};

			vm.Tasks.Add(task);
			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert("Invalid seleted category", "you must select category", "ok");
		}
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		var vm = BindingContext as NewTaskViewModel;

		string Newcategory =
			await DisplayPromptAsync("New Category", "Write the category name", maxLength: 15, keyboard: Keyboard.Text);

		var r = new Random();

		if (!string.IsNullOrEmpty(Newcategory))
		{
			vm.Categories.Add(new Category
			{
				Id = vm.Categories.Max(x => x.Id) + 1,
				Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)).ToHex(),
				CategoryName = Newcategory,
			});
		}
	}
}