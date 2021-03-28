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
            FooterButtonHomeBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
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