using ToDoListIDGS05.ViewModels;

namespace ToDoListIDGS05.Pages;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
		BindingContext = new RegistroViewModel(Navigation);
	}
}	