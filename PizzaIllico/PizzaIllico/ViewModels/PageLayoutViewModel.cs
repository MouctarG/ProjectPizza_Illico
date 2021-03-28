using PizzaIllico.Models.Library;
using PizzaIllico.Resources.Config;
using PizzaIllico.Services;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class PageLayoutViewModel : ViewModelBase
    {
        // user info
        protected string first_name;
        protected string last_name;
        protected string email;
        protected string password;
        protected string phone_number;

        // authentication
        protected IAuthenticationService authentificationService = DependencyService.Get<IAuthenticationService>();
        protected AuthenticationToken authentication_token = null;


        protected Dictionary<string, object> navigationParams = new Dictionary<string, object>();
        // ------------------------------------------------------------------------------------------

        protected Cart current_cart;

        private string errorMessage = "";


        public Command FooterButtonHomeCommand
        { get; set; }
        public Command FooterButtonAccountCommand { get; set; }
        public Command FooterButtonCartCommand { get; set; }
        public Command FooterButtonMapCommand { get; set; }

        public string ErrorMessage
        {
            get => errorMessage;
            set { SetProperty<string>(ref errorMessage, value); }
        }
        protected Dictionary<string, object> GetNavigationParameters()
        {
            return new Dictionary<string, object>()
                {
                    { Config.KEY_EMAIL, email },
                    { Config.KEY_PASSWORD, password },
                    { Config.KEY_PHONE_NUMBER, phone_number},
                    {Config.KEY_FIRST_NAME, first_name },
                    {Config.KEY_LAST_NAME, last_name },
                    {Config.KEY_AUTHENTICATION_TOKEN, authentication_token },
                    {Config.KEY_CART, current_cart }
                };
        }

        [NavigationParameter]
        public string Password
        {
            get => password;
            set { SetProperty<string>(ref password, value); }
        }
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
        public string Phone_number
        {
            get => phone_number;
            set { SetProperty<string>(ref phone_number, value); }
        }

        public AuthenticationToken Authentication_token
        {
            get => authentication_token;
            set => authentication_token = value;
        }

        public Cart CurrentCart { get => current_cart; set => current_cart = value; }

        public PageLayoutViewModel()
        {
            Authentication_token = authentificationService.GetToken<AuthenticationToken>();
            IsLoggedOut = !(authentication_token != null);
            SetLoggedInInfo();
        }
        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

            Email = GetNavigationParameter<string>(Config.KEY_EMAIL);
            Password = GetNavigationParameter<string>(Config.KEY_PASSWORD);
            Phone_number = GetNavigationParameter<string>(Config.KEY_PHONE_NUMBER);
            First_name = GetNavigationParameter<string>(Config.KEY_FIRST_NAME);
            Last_name = GetNavigationParameter<string>(Config.KEY_LAST_NAME);
            Authentication_token =  GetNavigationParameter<AuthenticationToken>(Config.KEY_AUTHENTICATION_TOKEN);
            Cart cart = GetNavigationParameter<Cart>(Config.KEY_CART);
            if (cart == null)
                CurrentCart = new Cart();
            else
                CurrentCart = cart;
            /**
             * if (!is_logged_in) HeaderLoggedInInfo = Config.MSG_LOGGED_OUT;
            else HeaderLoggedInInfo = Config.MSG_LOGGED_IN;
            */
        }

        protected string footerButtonAccountImage;
        protected string header_logged_in_info;
        protected bool is_logged_out;

        
        public string FooterButtonAccountImage
        {
            get => footerButtonAccountImage;
            set { SetProperty<string>(ref footerButtonAccountImage, value); }
        }
        public string HeaderLoggedInInfo {
            get => header_logged_in_info;
            set { SetProperty<string>(ref header_logged_in_info, value); }
        }

        public bool IsLoggedOut{
            get => is_logged_out;
            set { SetProperty<bool>(ref is_logged_out, value); }
        }
        protected void SetLoggedInInfo()
        {
            if (is_logged_out)
            {
                HeaderLoggedInInfo = Config.MSG_LOGGED_OUT;
                FooterButtonAccountImage = Config.RESOURCE_IMAGE_ACCOUNT;
            }
            else
            {
                HeaderLoggedInInfo = Config.MSG_LOGGED_IN;
                FooterButtonAccountImage = Config.RESOURCE_IMAGE_LOGGED_IN;
            }
        }
    }
}
