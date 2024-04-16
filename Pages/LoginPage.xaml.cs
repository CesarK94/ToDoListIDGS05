using ToDoListIDGS05.ViewModels;

namespace ToDoListIDGS05.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(Navigation);
    }
}