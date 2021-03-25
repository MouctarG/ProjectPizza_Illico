using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PizzeriaPage : PageLayoutTemplateControl
    {

        public PizzeriaPage(): base()
        {

            SetTemplateTemplateDefault();
            InitializeComponent();

            BindingContext = new PizzeriaViewModel();  
        }
       
    }
}