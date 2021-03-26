using PizzaIllico.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using PizzaIllico.Views;
using Storm.Mvvm;

using PizzaIllico.Models.Authentication;
using PizzaIllico.Resources.Config;
using PizzaIllico.Models.Library;
using System;
using Storm.Mvvm.Navigation;

namespace PizzaIllico.ViewModels
{
    class AccountViewModel : PageLayoutViewModel
    {

        private bool _isLoggedIn = false;

        // private string _userID = "";
        // private string _userPassword = "";

        private string _loginErrorMessage = "";

        AuthenticationToken _cachedOauth = null;

        IAuthenticationService _loginService = DependencyService.Get<IAuthenticationService>();

        public AccountViewModel()
        {
            LoginCommand = new Command(Do_login);

            // FooterButtonAccountIsEnabled = false;

            /**
            _cachedOauth = _loginService.GetToken<AuthenticationToken>();
            if (_cachedOauth != null)
            {
                IsLoggedIn = true;
                // debug messsage
                LoginErrorMessage = "[TOKEN STILL VALID] " + _cachedOauth.Access_token + " " + _cachedOauth.Refresh_token + " " + _cachedOauth.Expires_in;

                // navigate to the requested page (in the passed parameters) TODO: page de paiement ou home ou autre

            }
            else IsLoggedIn = false;
            */

            FooterButtonAccountCommand = new Command(() => { });

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()) );
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));

            // TODO
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()) );
           // -----------------------------------------------------------------------------------------------------------------------------------------


            GoToRegistrationCommand = new Command(async () => await NavigationService.PushAsync<ProfileRegistrationPage>(GetNavigationParameters()));

            GoToProfileUpdateCommand = new Command(async () => await NavigationService.PushAsync<ProfileUpdatePage>(GetNavigationParameters()));
            GoToPasswordUpdateCommand = new Command(async () => await NavigationService.PushAsync<PasswordUpdatePage>(GetNavigationParameters()));
            GoToOrderHistoryCommand = new Command(async () => await NavigationService.PushAsync<OrderHistoryPage>(GetNavigationParameters()));

        }

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }
        private async void Do_login(object obj)
        {
            DateTime start_time = DateTime.UtcNow;
            AuthenticationLoginResponse login_result = await _loginService.Login(new AuthenticationLoginRequest(Email, Password));

            is_logged_in = login_result.Is_success;

            if (is_logged_in)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(login_result.Data.Expires_in) + DateTime.UtcNow.Subtract(start_time);
                LoginErrorMessage = "";
                authentication_token = new AuthenticationToken(login_result.Data);

                _loginService.StoreToken<AuthenticationToken>(authentication_token, timeSpan);

                LoginErrorMessage = "[Succes] " + authentication_token.Access_token + " " + authentication_token.Refresh_token + " " + authentication_token.Expires_in;

                await NavigationService.PushAsync<HomePage>(GetNavigationParameters());
            }
            else
            {
                LoginErrorMessage = "[Error] " + login_result.Error_code;   // TODO: utiliser une resource statique
            }

        }

        // ---------------------------------------------------------------------------------------------------------


        public string LoginErrorMessage
        {
            get => _loginErrorMessage;
            set { SetProperty<string>(ref _loginErrorMessage, value); }
        }

        public Command GoToRegistrationCommand { get; }
        public Command GoToPasswordUpdateCommand { get;  }
        public Command GoToProfileUpdateCommand { get; }

        public Command GoToOrderHistoryCommand { get; }

        public Command LoginCommand { get; }

    }
}
