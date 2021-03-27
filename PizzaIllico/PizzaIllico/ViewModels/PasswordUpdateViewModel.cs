using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PizzaIllico.Models.Library;
using PizzaIllico.Models.Authentication;
using PizzaIllico.Services;

namespace PizzaIllico.ViewModels
{
    class PasswordUpdateViewModel: PageLayoutViewModel
    {
        private string _new_password;
        public PasswordUpdateViewModel()
        {
           
            // -----------------------------------------------------------------------------------------------------------------------------------------

            ExecuteCommand = new Command(Do_update_password);

            FooterButtonBackArrow = new Command(async () => await NavigationService.PopAsync());

        }

        public string New_password
        {
            get => _new_password;
            set { SetProperty<string>(ref _new_password, value); }
        }

        public Command FooterButtonBackArrow { get; }
        public Command ExecuteCommand { get; }

        private async void Do_update_password()
        {
            if(is_logged_out)
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Please Login first", "OK");
                await NavigationService.PopAsync();
            }
            else
            {
                IAccountService accountService = DependencyService.Get<IAccountService>();
                AuthenticationPasswordPatchRequest passwordPatchRequest = new AuthenticationPasswordPatchRequest(password, _new_password);

                AuthenticationPasswordPatchResponse response = await accountService.ChangePassword(passwordPatchRequest, authentication_token.Access_token);
                
                if (response.Is_success)
                {
                    await Application.Current.MainPage.DisplayAlert("Information", "Password updated successfully", "OK");
                    await NavigationService.PopAsync();
                } else
                {
                    string msg = response.ToString();
                    await Application.Current.MainPage.DisplayAlert("Alert", "The Password couldn't be modified" + msg, "OK");
                }

            }
        }

    }
}
