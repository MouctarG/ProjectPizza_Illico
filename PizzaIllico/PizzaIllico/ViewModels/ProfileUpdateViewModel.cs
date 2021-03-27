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
    class ProfileUpdateViewModel : PageLayoutViewModel
    {
        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }
        public ProfileUpdateViewModel()
        {

            FooterButtonBackArrow = new Command(async () => await NavigationService.PopAsync());
            ExecuteCommand = new Command(Do_update_profile);
        }

        // -------------------------------------------------------------------------------------------------------------
        private async void Do_update_profile()
        {
            if (is_logged_out)
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Please Login first", "OK");
                await NavigationService.PopAsync();
            }
            else
            {
                IAccountService accountService = DependencyService.Get<IAccountService>();
                AccountInformationPatchRequest accountInformationPatchRequest = new AccountInformationPatchRequest(
                    email, first_name, last_name, phone_number, authentication_token.Access_token);

                AccountInformationPatchResponse response = await accountService.ChangeUserProfile(accountInformationPatchRequest, authentication_token.Access_token);

                if (response.Is_success)
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "User info updated successfully", "OK");
                    await NavigationService.PopAsync();
                }
                else
                {
                    string msg = response.ToString();
                    await Application.Current.MainPage.DisplayAlert("Alert", "User info couldn't be updated" + msg, "OK");
                }

            }
        }

        public Command FooterButtonBackArrow { get; }
        public Command ExecuteCommand { get; }

    }
}
