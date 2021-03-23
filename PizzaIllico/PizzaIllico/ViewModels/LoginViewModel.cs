using PizzaIllico.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using PizzaIllico.Views;
using Storm.Mvvm;

using PizzaIllico.Models.Authentication;
using PizzaIllico.Resources.Config;
using PizzaIllico.Models.Library;
using System;

namespace PizzaIllico.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private bool _isLoggedIn = false;

        private string _userID = "";
        private string _userPassword = "";

        private string _loginErrorMessage = "";

        AuthenticationToken _cachedOauth = null;

        IAuthenticationService _loginService = DependencyService.Get<IAuthenticationService>();

        public LoginViewModel()
        {
            LoginCommand = new Command(Do_login);
            GoToRegistrationCommand = new Command(Do_register);

            _cachedOauth = _loginService.GetToken<AuthenticationToken>();
            if (_cachedOauth != null)
            {
                IsLoggedIn = true;
                // debug messsage
                LoginErrorMessage = "[TOKEN STILL VALID] " + _cachedOauth.Access_token + " " + _cachedOauth.Refresh_token + " " + _cachedOauth.Expires_in;

                // navigate to the requested page (in the passed parameters) TODO: page de paiement ou home ou autre

            }
            else IsLoggedIn = false;

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

            DateTime start_time = DateTime.UtcNow;
            AuthenticationLoginResponse login_result = await _loginService.Login(new AuthenticationLoginRequest(UserID, UserPassword));

           IsLoggedIn = login_result.Is_success;

            if (login_result.Is_success)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(login_result.Data.Expires_in) + DateTime.UtcNow.Subtract(start_time);
                LoginErrorMessage = "";
                _cachedOauth = new AuthenticationToken(login_result.Data);

                _loginService.StoreToken<AuthenticationToken>(_cachedOauth, timeSpan);

                LoginErrorMessage = "[Succes] " + _cachedOauth.Access_token + " " + _cachedOauth.Refresh_token + " " + _cachedOauth.Expires_in;
            }
            else LoginErrorMessage = "[Error] " + login_result.Error_code;   // TODO: utiliser une resource statique


            if(login_result.Is_success) LoginErrorMessage = "";
            else LoginErrorMessage = "[Error] " + login_result.Error_message;   // TODO: utiliser une resource statique

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
