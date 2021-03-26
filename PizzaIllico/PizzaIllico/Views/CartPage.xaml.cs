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
    public partial class CartPage : PageLayoutTemplateControl
    {
        private void SetHomePageLayout()
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

            FooterButtonCartIsEnabled = false;
            FooterButtonCartTextColor = disabledButtonTextColor;
            FooterButtonCartBackgroundColor = disabledButtonBackgroundColor;

            PageTitle = "Order";
        }
        public CartPage() : base()
        {

            SetHomePageLayout();
            InitializeComponent();

            BindingContext = new CartViewModel();


        }
    }
}