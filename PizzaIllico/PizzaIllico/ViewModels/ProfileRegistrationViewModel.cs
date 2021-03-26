using PizzaIllico.Models.Account;
using PizzaIllico.Models.Library;
using PizzaIllico.Services;
using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class ProfileRegistrationViewModel: PageLayoutViewModel
    {
        private bool _isRegistered = false;

        IAccountService _loginService = DependencyService.Get<IAccountService>();

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

        }
        public ProfileRegistrationViewModel()
        {

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));


            ExecuteCommand = new Command(Do_register);

        }

        private async void Do_register(object obj)
        {
            // string email, string first_name, string last_name, string phone_number, string password

            AccountRegistrationResponse registration_result = await _loginService.Register(new AccountRegistrationRequest(Email, First_name, Last_name, Phone_number, Password));

            IsRegistered = registration_result.Is_success;

            if (IsRegistered)
            {
                ErrorMessage = "";
                await NavigationService.PushAsync<HomePage>(GetNavigationParameters());
            }
            else ErrorMessage = "[Error] " + registration_result.Error_message;  // TODO: utiliser une resource statique

            // TODO: Navigate to the restaurant list

        }


        // -------------------------------------------------------------------------------------------------------------
       
        public bool IsRegistered
        {
            get => _isRegistered;
            set { SetProperty<bool>(ref _isRegistered, value); }
        }


        public Command ExecuteCommand { get; }
    }
}
