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

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

        }
        public ProfileRegistrationViewModel()
        {

            FooterButtonBackArrow = new Command(async () => await NavigationService.PopAsync());

            ExecuteCommand = new Command(Do_register);

        }

        private async void Do_register(object obj)
        {
            IAccountService accountService = DependencyService.Get<IAccountService>();
            AccountRegistrationResponse response = await accountService.Register(new AccountRegistrationRequest(Email, First_name, Last_name, Phone_number, Password));

            if (response.Is_success)
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Registration successfull", "OK");
                await NavigationService.PopAsync();
            }
            else
            {
                string msg = response.ToString();
                await Application.Current.MainPage.DisplayAlert("Alert", "Registration failed" + msg, "OK");
            }
        }


        // -------------------------------------------------------------------------------------------------------------
        public Command ExecuteCommand { get; }
        public Command FooterButtonBackArrow { get;  }
    }
}
