using PizzaIllico.Models;
using PizzaIllico.Resources.Config;
using PizzaIllico.Services;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        private bool _isRegistered = false;

        private string first_name;
        private string last_name;
        private string email;
        private string password;
        private string phone_number;
        private string registrationErrorMessage;

        ILoginService _loginService = DependencyService.Get<ILoginService>();

        public RegistrationViewModel()
        {

            RegisterCommand = new Command(Do_register);

        }

        private async void Do_register(object obj)
        {
            // string email, string first_name, string last_name, string phone_number, string password

            RequestResult registration_result = await _loginService.Register(new User(Email, First_name, Last_name, Phone_number, Password));

            IsRegistered = registration_result.Is_success;

            if (IsRegistered) RegistrationErrorMessage = "";
            else RegistrationErrorMessage = "[Error] " + Config.ToString(registration_result.Error_code);  // TODO: utiliser une resource statique

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
