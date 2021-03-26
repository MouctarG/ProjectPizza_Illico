using PizzaIllico.Controls;
using PizzaIllico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : PageLayoutTemplateControl
    {
        private void SetProfilePageLayout(PizzaIllico.Resources.Config.EnumPages style)
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

            PageTitle = (style == PizzaIllico.Resources.Config.EnumPages.REGISTRATION )?  "Registration" : "Profile update";
        }
        public ProfilePage(PizzaIllico.Resources.Config.EnumPages page)
        {
            
            if ( page == PizzaIllico.Resources.Config.EnumPages.REGISTRATION)
            {
                SetProfilePageLayout(PizzaIllico.Resources.Config.EnumPages.REGISTRATION);
                
                InitializeComponent();
                BindingContext = new ProfileRegistrationViewModel();
            }
            else
            {
                SetProfilePageLayout(PizzaIllico.Resources.Config.EnumPages.PROFILE_UPDATE);
                
                InitializeComponent();
                BindingContext = new ProfileUpdateViewModel();

            }
        }
    }
}