using Newtonsoft.Json;
using Firebase.Auth;
using ToDoListIDGS05.ViewModels;
using ToDoListIDGS05.Pages;

namespace ToDoListIDGS05
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ValidateToken();
        }

        private async void ValidateToken()
        {
            var token = Preferences.Get("FreshFirebaseToken", "");
            if (string.IsNullOrEmpty(token))
            {
                await Navigation.PushAsync(new LoginPage());
                return;
            }
            else
            {
                await Navigation.PushAsync(new Dashboard());
            }
        }

    }

}
