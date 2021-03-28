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
    public partial class PasswordUpdatePage : PageLayoutTemplateControl
    {

        protected void SetPasswordUpdatePageLayout()
        {
            FooterButtonHomeIsEnabled = true;
            FooterButtonHomeBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonAccountIsEnabled = true;
            FooterButtonAccountBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonMapIsEnabled = true;
            FooterButtonMapBackgroundColor = enabledButtonBackgroundColor;

            FooterButtonCartIsEnabled = true;
            FooterButtonCartBackgroundColor = enabledButtonBackgroundColor;

            PageTitle = "Password Update";
        }
        public PasswordUpdatePage()
        {
            SetPasswordUpdatePageLayout();
            InitializeComponent();

            BindingContext = new PasswordUpdateViewModel();
        }
    }
}