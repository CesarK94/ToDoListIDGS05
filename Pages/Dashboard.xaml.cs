
using Firebase.Auth;
using Newtonsoft.Json;
using ToDoListIDGS05.ViewModels;

namespace ToDoListIDGS05.Pages;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
		GetProfileInfo();
		BindingContext = new DashboardViewModel(Navigation);
	}

    private void GetProfileInfo()
    {
		var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        UserEmial.Text = userInfo.User.Email;
    }

}