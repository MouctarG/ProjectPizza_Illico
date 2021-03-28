using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PizzeriaPage : PageLayoutTemplateControl
    {
        private void SetPizzeriaPageLayout()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Pizza selection";

        }
        public PizzeriaPage(): base()
        {

            SetPizzeriaPageLayout();
            InitializeComponent();

            BindingContext = new PizzeriaViewModel();  
        }
       
    }
}