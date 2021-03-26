using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : PageLayoutTemplateControl
    {
        private void SetHomePageLayout()
        {
            FooterButtonHomeIsEnabled = false;
            FooterButtonHomeTextColor = disabledButtonTextColor;
            FooterButtonHomeBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountTextColor = enabledButtonTextColor;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartTextColor = enabledButtonTextColor;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Pizzerias";
        }
        public HomePage(): base()
        {

            SetHomePageLayout();
            InitializeComponent();

            BindingContext = new HomeViewModel();
            

        }
    }
}