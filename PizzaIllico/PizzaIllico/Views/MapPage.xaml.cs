using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : PageLayoutTemplateControl
    {
        protected void SetMapPageLayout()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountTextColor = enabledButtonTextColor;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = false;
            FooterButtonMapTextColor = disabledButtonTextColor;
            FooterButtonMapBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartTextColor = enabledButtonTextColor;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Pizzerias Location";
        }
        public MapPage(): base()
        {
            SetMapPageLayout();
            InitializeComponent();

            BindingContext = new MapViewModel();

        }
       
    }
}