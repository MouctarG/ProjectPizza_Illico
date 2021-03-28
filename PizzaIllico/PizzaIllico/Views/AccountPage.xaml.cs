using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AccountPage : PageLayoutTemplateControl
    {
        private void SetAccountPageLayout()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = false;
            FooterButtonAccountBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Account";
        }
        public AccountPage(): base()
        {

            SetAccountPageLayout();
            InitializeComponent();

            BindingContext = new AccountViewModel();

        }
       
    }
}