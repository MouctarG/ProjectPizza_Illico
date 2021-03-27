using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

using Xamarin.Forms.Xaml;



namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUpdatePage : PageLayoutTemplateControl
    {

        private void SetProfilePageLayout()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeTextColor = enabledButtonTextColor;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountTextColor = enabledButtonTextColor;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapTextColor = enabledButtonTextColor;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartTextColor = enabledButtonTextColor;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Profile update";
        }
        public ProfileUpdatePage()
        {
            SetProfilePageLayout();

            InitializeComponent();
            BindingContext = new ProfileUpdateViewModel();

        }
    }
}