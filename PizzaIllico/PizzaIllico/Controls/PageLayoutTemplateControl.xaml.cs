using PizzaIllico.Resources.Config;
using PizzaIllico.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLayoutTemplateControl : ContentPage
    {

        private static Color disabledButtonBackgroundColor = Color.DeepSkyBlue;
        private static Color enabledButtonBackgroundColor = Color.Azure;

        private Command _goToLoginCommand;
        private Command _goToMapCommand;
        private Command _goHomeCommand;
        private Command _goToRegistrationCommand;

        private bool _goHomeIsEnabled = true;
        private bool _goToRegistrationIsEnabled = true;
        private bool _goToMapIsEnabled = true;
        private bool _goToLoginIsEnabled = true;

        private Color _goHomeButtonBackgroundColor = enabledButtonBackgroundColor;
        private Color _goToLoginButtonBackgroundColor = enabledButtonBackgroundColor;
        private Color _goToRegistrationButtonBackgroundColor = enabledButtonBackgroundColor;
        private Color _goToMapButtonBackgroundColor = enabledButtonBackgroundColor;


        public bool GoHomeIsEnabled
        {

            get => _goHomeIsEnabled;
            set => _goHomeIsEnabled = value;
        }
        public bool GoToRegistrationIsEnabled
        {

            get => _goToRegistrationIsEnabled;
            set => _goToRegistrationIsEnabled = value;
        }
        public bool GoToMapIsEnabled
        {

            get => _goToMapIsEnabled;
            set => _goToMapIsEnabled = value;
        }
        public bool GoToLoginIsEnabled
        {

            get => _goToLoginIsEnabled;
            set => _goToLoginIsEnabled = value;
        }


        public Command GoToLoginCommand
        {
            get => _goToLoginCommand; 
            set => _goToLoginCommand = value;
        }
        public Command GoToMapCommand
        {
            get => _goToMapCommand; 
            set => _goToMapCommand = value;
        }
        public Command GoHomeCommand
        {
            get => _goHomeCommand; 
            set => _goHomeCommand = value;
        }
        public Command GoToRegistrationCommand
        {
            get => _goToRegistrationCommand; 
            set => _goToRegistrationCommand = value;
        }

        public Color GoHomeButtonBackgroundColor
        {
            get => _goHomeButtonBackgroundColor;
            set => _goHomeButtonBackgroundColor = value;
        }
      
        public Color GoToLoginButtonBackgroundColor
        {
            get => _goToLoginButtonBackgroundColor; 
            set => _goToLoginButtonBackgroundColor = value;
        }
     
        public Color GoToRegistrationButtonBackgroundColor
        {
            get => _goToRegistrationButtonBackgroundColor; 
            set => _goToRegistrationButtonBackgroundColor = value;
        }
        public Color GoToMapButtonBackgroundColor
        {
            get => _goToMapButtonBackgroundColor; 
            set => _goToMapButtonBackgroundColor = value;
        }

        public PageLayoutTemplateControl(EnumPages page)
        {
            if (page == EnumPages.HOME)
            {
                GoHomeIsEnabled = false;
                GoHomeButtonBackgroundColor = disabledButtonBackgroundColor;
            }
            else if (page == EnumPages.LOGIN)
            {
                GoToLoginIsEnabled = false;
                GoToLoginButtonBackgroundColor = disabledButtonBackgroundColor;
            }
            else if (page == EnumPages.MAP)
            {
                GoToMapIsEnabled = false;
                GoToMapButtonBackgroundColor = disabledButtonBackgroundColor;
            }
            else if (page == EnumPages.REGISTRATION)
            {
                GoToRegistrationIsEnabled = false;
                GoToRegistrationButtonBackgroundColor = disabledButtonBackgroundColor;
            }


            _goHomeCommand = new Command(() => { if (_goHomeIsEnabled) Go_home(); });
            _goToMapCommand = new Command(() => { if (_goToMapIsEnabled) Go_ToMap(); });
            _goToRegistrationCommand = new Command(() => { if (_goToRegistrationIsEnabled) Go_ToRegistration(); });
            _goToLoginCommand = new Command(() => { if (_goToLoginIsEnabled) Go_ToLogin(); });

            InitializeComponent();
        }

        private async void Go_home()
        {

            var loginPage = new NavigationPage(new HomePage());

            await Application.Current.MainPage.Navigation.PushAsync(loginPage);
        }
        private async void Go_ToLogin()
        {

            var loginPage = new NavigationPage(new LoginPage());

            await Application.Current.MainPage.Navigation.PushAsync(loginPage);
        }
        private async void Go_ToMap()
        {

            var mapPage = new NavigationPage(new MapPage());

            await Application.Current.MainPage.Navigation.PushAsync(mapPage);
        }
        private async void Go_ToRegistration()
        {

            var registrationPage = new NavigationPage(new RegistrationPage());

            await Application.Current.MainPage.Navigation.PushAsync(registrationPage);
        }

    }
}