using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : PageLayoutTemplateControl
    {
        public LoginPage(): base(PizzaIllico.Resources.Config.EnumPages.LOGIN)
        {
           
            InitializeComponent();
          
            BindingContext = new LoginViewModel();

        }
       
    }
}