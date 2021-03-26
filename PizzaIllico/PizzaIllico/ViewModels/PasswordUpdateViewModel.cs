using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class PasswordUpdateViewModel: PageLayoutViewModel
    {
        public PasswordUpdateViewModel()
        {
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));

            // TODO
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));
            // -----------------------------------------------------------------------------------------------------------------------------------------

        }
    }
}
