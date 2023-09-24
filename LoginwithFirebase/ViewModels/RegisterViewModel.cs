using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginwithFirebase.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        public string webApiKey = "apikey";

        private INavigation _navigation;

        private string email;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get => email; 
            set {
                email = value;
                RaisePropertyChanged("Email");
            } 
        }

        public string Password { get => password; set {
                password = value; 
                RaisePropertyChanged("Password");
            } }

        public Command RegisterUser { get; }

        private void RaisePropertyChanged(string v) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation) 
        { 
            this._navigation = navigation;
            

            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if (token == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "User Registered Successfully", "OK");
                }
                await this._navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
