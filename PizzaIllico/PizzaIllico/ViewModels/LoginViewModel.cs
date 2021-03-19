using PizzaIllico.Models;
using PizzaIllico.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using PizzaIllico.Views;
using Storm.Mvvm;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private bool _isLoggedIn = false;

        private string _userID = "";
        private string _userPassword = "";

        private string _loginErrorMessage = "";

        ILoginService _loginService = DependencyService.Get<ILoginService>();

        public LoginViewModel()
        {
            LoginCommand = new Command(Do_login);
            GoToRegistrationCommand = new Command(Do_register);

        }

        private async void Do_register(object obj)
        {
            
            var registrationPage = new RegistrationPage();
            Dictionary<string, object> navigationParams = new Dictionary<string, object>()
            {
                {Config.KEY_EMAIL, UserID },
                {Config.KEY_PASSWORD, UserPassword }
            };

            await NavigationService.PushAsync<RegistrationPage>(navigationParams);

        }

        private async void Do_login(object obj)
        {

            LoginOutput login_result = await _loginService.Login(new LoginInput(UserID, UserPassword));

           IsLoggedIn = login_result.Result.Is_success;

            if(login_result.Result.Is_success) LoginErrorMessage = "";
            else LoginErrorMessage = "[Error] " + Config.ToString(login_result.Result.Error_code);   // TODO: utiliser une resource statique

        }


        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set { SetProperty<bool>(ref _isLoggedIn, value); }
        }


        public string UserID
        {
            get => _userID;
            set { SetProperty<string>(ref _userID, value); }
        }

        public string UserPassword
        {
            get => _userPassword;
            set { SetProperty<string>(ref _userPassword, value); }
        }

        public string LoginErrorMessage
        {
            get => _loginErrorMessage;
            set { SetProperty<string>(ref _loginErrorMessage, value); }
        }

        public Command GoToRegistrationCommand { get; }
        public Command LoginCommand { get; }
    }
}
