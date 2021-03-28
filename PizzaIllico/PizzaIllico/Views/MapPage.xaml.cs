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
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = false;
            FooterButtonMapBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
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