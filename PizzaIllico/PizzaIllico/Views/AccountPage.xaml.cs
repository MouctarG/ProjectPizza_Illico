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
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = false;
            FooterButtonAccountTextColor = disabledButtonTextColor;
            FooterButtonAccountBackgroundColor = disabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartTextColor = enabledButtonTextColor;
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