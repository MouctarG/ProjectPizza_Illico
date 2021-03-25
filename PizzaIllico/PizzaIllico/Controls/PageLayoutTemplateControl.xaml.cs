using PizzaIllico.Resources.Config;
using PizzaIllico.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLayoutTemplateControl : ContentPage
    {

        protected static Color disabledButtonBackgroundColor = Color.DeepSkyBlue;
        protected static Color enabledButtonBackgroundColor = Color.Azure;

        protected static Color enabledButtonTextColor = Color.DarkSlateGray;
        protected static Color disabledButtonTextColor = Color.DarkSlateGray;


        public Color FooterEnabledButtonTextColor
        {
            get => enabledButtonTextColor;
            set => enabledButtonTextColor = value;
        }

        public Color FooterDisabledButtonTextColor
        {
            get => disabledButtonTextColor;
            set => disabledButtonTextColor = value;
        }
        public Color FooterEnabledButtonBackgroundColor
        {
            get => enabledButtonBackgroundColor;
            set => enabledButtonBackgroundColor = value;
        }
        public Color FooterDisabledButtonBackgroundColor
        {
            get => disabledButtonBackgroundColor;
            set => disabledButtonBackgroundColor = value;
        }
       

        public bool FooterButtonHomeIsEnabled { get; set; }
        public bool FooterButtonLoginIsEnabled { get; set; }
        public bool FooterButtonRegistrationIsEnabled { get; set; }
        public bool FooterButtonMapIsEnabled { get; set; }

        public Color FooterButtonHomeTextColor { get; set; }
        public Color FooterButtonLoginTextColor { get; set; }
        public Color FooterButtonRegistrationTextColor { get; set; }
        public Color FooterButtonMapTextColor { get; set; }

        public Color FooterButtonHomeBackgroundColor { get; set; }
        public Color FooterButtonLoginBackgroundColor { get; set; }
        public Color FooterButtonRegistrationBackgroundColor { get; set; }
        public Color FooterButtonMapBackgroundColor { get; set; }

        // =======================================================================================================================================
        protected void SetTemplateDisabledButtonHome()
        {
            FooterButtonHomeIsEnabled = false;
            FooterButtonHomeTextColor = disabledButtonTextColor;
            FooterButtonHomeBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonLoginIsEnabled = true;
            FooterButtonLoginTextColor = enabledButtonTextColor;
            FooterButtonLoginBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonRegistrationIsEnabled = true;
            FooterButtonRegistrationTextColor = enabledButtonTextColor;
            FooterButtonRegistrationBackgroundColor = enabledButtonBackgroundColor;
        }

        protected void SetTemplateDisabledButtonLogin()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonLoginIsEnabled = false;
            FooterButtonLoginTextColor = disabledButtonTextColor;
            FooterButtonLoginBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonRegistrationIsEnabled = true;
            FooterButtonRegistrationTextColor = enabledButtonTextColor;
            FooterButtonRegistrationBackgroundColor = enabledButtonBackgroundColor;
        }

        protected void SetTemplateDisabledButtonRegistration()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonLoginIsEnabled = true;
            FooterButtonLoginTextColor = enabledButtonTextColor;
            FooterButtonLoginBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonRegistrationIsEnabled = false;
            FooterButtonRegistrationTextColor = disabledButtonTextColor;
            FooterButtonRegistrationBackgroundColor = disabledButtonBackgroundColor;
        }

        protected void SetTemplateTemplateDefault()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonLoginIsEnabled = true;
            FooterButtonLoginTextColor = enabledButtonTextColor;
            FooterButtonLoginBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonRegistrationIsEnabled = true;
            FooterButtonRegistrationTextColor = enabledButtonTextColor;
            FooterButtonRegistrationBackgroundColor = enabledButtonBackgroundColor;

        }
        protected void SetTemplateDisabledButtonMap()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonLoginIsEnabled = true;
            FooterButtonLoginTextColor = enabledButtonTextColor;
            FooterButtonLoginBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = false;
            FooterButtonMapTextColor = disabledButtonTextColor;
            FooterButtonMapBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonRegistrationIsEnabled = true;
            FooterButtonRegistrationTextColor = enabledButtonTextColor;
            FooterButtonRegistrationBackgroundColor = enabledButtonBackgroundColor;
        }
         
        public PageLayoutTemplateControl()
        {
            InitializeComponent();
        }
        
    }
}