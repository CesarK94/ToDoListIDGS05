using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListIDGS05.ViewModels
{
    internal class RegistroViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private string email;
        private string password;
        public string webApKey = "AIzaSyA96ynqRYTGjjNIOvLcu8rMnPTqDcOncEE";

        public string Email { get => email; set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password { get => password; set 
            { 
                password = value; 
                RaisePropertyChanged("Password");
            } 
        }
        public Command RegisterUser { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegistroViewModel(INavigation navigation)
        {
            this._navigation = navigation;

            RegisterUser = new Command(RegisterUserTappedAsync);

        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if (token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Usuario Registrado", "Ok");
                    await this._navigation.PopAsync();
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                throw;
            }
        }
    }
}
