using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListIDGS05.Pages;

namespace ToDoListIDGS05.ViewModels
{
    internal class DashboardViewModel
    {
        private INavigation navigation;

        public Command Logout { get; }

        public DashboardViewModel(INavigation navigation)
        {
            this.navigation = navigation;

            Logout = new Command(LogoutAsync);
        }

        private async void LogoutAsync(object obj)
        {
            Preferences.Remove("FreshFirebaseToken");
            await this.navigation.PopAsync();
        }
    }
}
