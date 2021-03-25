using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : PageLayoutTemplateControl
    {
        public RegistrationPage(): base()
        {

            SetTemplateDisabledButtonRegistration();
            InitializeComponent();

            BindingContext = new RegistrationViewModel();
        }
       
    }
}