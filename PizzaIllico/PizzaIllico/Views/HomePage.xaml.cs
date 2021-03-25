using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.ViewModels;
using PizzaIllico.Controls;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : PageLayoutTemplateControl
    {
        
        public HomePage(): base()
        {

            SetTemplateDisabledButtonHome();
            InitializeComponent();

            BindingContext = new HomeViewModel();
            

        }
    }
}