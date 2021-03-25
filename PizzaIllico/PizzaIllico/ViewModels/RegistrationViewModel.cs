using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using System.Collections.Generic;
using Xamarin.Forms;

using PizzaIllico.Models.Account;
using PizzaIllico.Resources.Config;
using PizzaIllico.Services;
using PizzaIllico.Views;

namespace PizzaIllico.ViewModels
{
    class RegistrationViewModel : PageLayoutViewModel
    {
        private bool _isRegistered = false;

        private string first_name;
        private string last_name;
        private string email;
        private string password;
        private string phone_number;
        private string registrationErrorMessage;

        IAccountService _loginService = DependencyService.Get<IAccountService>();

        public RegistrationViewModel()
        {

            // FooterButtonRegistrationIsEnabled = false;

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>());
            FooterButtonLoginCommand = new Command(async () => await NavigationService.PushAsync<LoginPage>());
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>());
            FooterButtonRegistrationCommand = new Command(() => { });

            RegisterCommand = new Command(Do_register);

        }

        private async void Do_register(object obj)
        {
            // string email, string first_name, string last_name, string phone_number, string password

            AccountRegistrationResponse registration_result = await _loginService.Register(new AccountRegistrationRequest(Email, First_name, Last_name, Phone_number, Password));

            IsRegistered = registration_result.Is_success;

            if (IsRegistered) RegistrationErrorMessage = "";
            else RegistrationErrorMessage = "[Error] " + registration_result.Error_message;  // TODO: utiliser une resource statique

            // TODO: Navigate to the restaurant list

        }

        [NavigationParameter]
        public string First_name
        {
            get => first_name;
            set { SetProperty<string>(ref first_name, value); }
        }
        public string Last_name
        {
            get => last_name;
            set { SetProperty<string>(ref last_name, value); }
        }
        public string Email
        {
            get => email;
            set { SetProperty<string>(ref email, value); }
        }
        public string Password
        {
            get => password;
            set { SetProperty<string>(ref password, value); }
        }
        public string Phone_number
        {
            get => phone_number;
            set { SetProperty<string>(ref phone_number, value); }
        }

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

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

            Email = GetNavigationParameter<string>(Config.KEY_EMAIL);
            Password = GetNavigationParameter<string>(Config.KEY_PASSWORD);
        }

        public Command RegisterCommand { get; }
    }
}
