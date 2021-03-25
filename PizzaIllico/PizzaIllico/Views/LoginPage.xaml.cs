using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : PageLayoutTemplateControl
    {
        public LoginPage(): base()
        {

            SetTemplateDisabledButtonLogin();
            InitializeComponent();

            BindingContext = new LoginViewModel();

        }
       
    }
}