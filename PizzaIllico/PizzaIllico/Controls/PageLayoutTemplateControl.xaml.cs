using PizzaIllico.Resources.Config;
using PizzaIllico.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLayoutTemplateControl : ContentPage
    {
        /**
        protected static Color disabledButtonBackgroundColor = Color.DeepSkyBlue;
        protected static Color enabledButtonBackgroundColor = Color.Azure;

        protected static Color enabledButtonTextColor = Color.DarkSlateGray;
        protected static Color disabledButtonTextColor = Color.DarkSlateGray;
        */
        protected static Color disabledButtonBackgroundColor = Color.White;
        protected static Color enabledButtonBackgroundColor = Color.Black;

        protected static Color enabledButtonTextColor = Color.DarkSlateGray;
        protected static Color disabledButtonTextColor = Color.White;
        

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
        public bool FooterButtonAccountIsEnabled { get; set; }
        public bool FooterButtonCartIsEnabled { get; set; }
        public bool FooterButtonMapIsEnabled { get; set; }

        public string PageTitle { get; set; }

        public Color FooterButtonHomeTextColor { get; set; }
        public Color FooterButtonAccountTextColor { get; set; }
        public Color FooterButtonCartTextColor { get; set; }
        public Color FooterButtonMapTextColor { get; set; }

        public Color FooterButtonHomeBackgroundColor { get; set; }
        public Color FooterButtonAccountBackgroundColor { get; set; }
        public Color FooterButtonCartBackgroundColor { get; set; }
        public Color FooterButtonMapBackgroundColor { get; set; }

        // =======================================================================================================================================
        

        

        

        
        
         
        public PageLayoutTemplateControl()
        {
            InitializeComponent();
        }
        
    }
}