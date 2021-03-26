using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PizzaIllico.Models.Library;

namespace PizzaIllico.ViewModels
{
    class PasswordUpdateViewModel: PageLayoutViewModel
    {
        private string _new_password;
        public PasswordUpdateViewModel()
        {
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));

            // TODO
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));
            // -----------------------------------------------------------------------------------------------------------------------------------------

            ExecuteCommand = new Command(Do_update_password);

        }

        public string New_password
        {
            get => _new_password;
            set { SetProperty<string>(ref _new_password, value); }
        }

        public Command ExecuteCommand { get; }

        private void Do_update_password()
        {
            // TODO
        }

    }
}
