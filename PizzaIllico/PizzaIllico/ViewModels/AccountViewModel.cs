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
        private EnumPages targetPage = EnumPages.LOGIN;
        public AccountViewModel()
        {
            LoginCommand = new Command(Do_login);

            FooterButtonAccountCommand = new Command(() => { });

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()) );
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));

            // TODO
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()) );
           // -----------------------------------------------------------------------------------------------------------------------------------------


            GoToRegistrationCommand = new Command(async () => await NavigationService.PushAsync<ProfileRegistrationPage>(GetNavigationParameters()));

            GoToProfileUpdateCommand = new Command(async () =>
            {
                targetPage = EnumPages.PROFILE_UPDATE;
                if (is_logged_out) await Application.Current.MainPage.DisplayAlert("Information", "Please login first", "OK");
                else await NavigationService.PushAsync<ProfileUpdatePage>(GetNavigationParameters());
            });
            GoToPasswordUpdateCommand = new Command(async () =>
            {
                targetPage = EnumPages.PASSWORD_UPDATE;
                if(is_logged_out) await Application.Current.MainPage.DisplayAlert("Information", "Please login first", "OK");
                else await NavigationService.PushAsync<PasswordUpdatePage>(GetNavigationParameters());
            });
            GoToOrderHistoryCommand = new Command(async () =>
            {
                targetPage = EnumPages.ORDER_HISTORY;
                if (is_logged_out) await Application.Current.MainPage.DisplayAlert("Information", "Please login first", "OK");
                else await NavigationService.PushAsync<OrderHistoryPage>(GetNavigationParameters());
            });

        }

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }
        private async void Do_login(object obj)
        {
            DateTime start_time = DateTime.UtcNow;
            AuthenticationLoginResponse login_result = await authentificationService.Login(new AuthenticationLoginRequest(Email, Password));

            IsLoggedOut = !login_result.Is_success;

            if (!is_logged_out)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(login_result.Data.Expires_in) + DateTime.UtcNow.Subtract(start_time);
                ErrorMessage = "";
                authentication_token = new AuthenticationToken(login_result.Data);

                authentificationService.StoreToken<AuthenticationToken>(authentication_token, timeSpan);

                // ErrorMessage = "[Succes] " + authentication_token.Access_token + " " + authentication_token.Refresh_token + " " + authentication_token.Expires_in;

                SetLoggedInInfo();

                if( targetPage == EnumPages.HOME) await NavigationService.PushAsync<HomePage>(GetNavigationParameters());
                else if(targetPage == EnumPages.PASSWORD_UPDATE) await NavigationService.PushAsync<PasswordUpdatePage>(GetNavigationParameters());
            }
            else
            {
                ErrorMessage = "[Error] " + login_result.Error_code;   // TODO: utiliser une resource statique
            }

        }

        // ---------------------------------------------------------------------------------------------------------

        public Command GoToRegistrationCommand { get; }
        public Command GoToPasswordUpdateCommand { get;  }
        public Command GoToProfileUpdateCommand { get; }

        public Command GoToOrderHistoryCommand { get; }

        public Command LoginCommand { get; }

    }
}
