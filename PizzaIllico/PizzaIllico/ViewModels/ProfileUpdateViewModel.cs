using PizzaIllico.Models.Library;
using PizzaIllico.Services;
using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class ProfileUpdateViewModel : PageLayoutViewModel
    {
        private bool _isRegistered = false;


        private string registrationErrorMessage;

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }
        public ProfileUpdateViewModel()
        {

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));

            RegisterCommand = new Command(Do_register);
        }


        private async void Do_register(object obj)
        {
            // string email, string first_name, string last_name, string phone_number, string password

            

            // TODO: Navigate to the restaurant list

        }


        // -------------------------------------------------------------------------------------------------------------
        public string RegistrationErrorMessage
        {
            get => registrationErrorMessage;
            set { SetProperty<string>(ref registrationErrorMessage, value); }
        }

        public bool IsRegistered
        {
            get => _isRegistered;
            set { SetProperty<bool>(ref _isRegistered, value); }
        }


        public Command RegisterCommand { get; }

    }
}
