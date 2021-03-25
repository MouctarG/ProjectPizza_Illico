using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : PageLayoutTemplateControl
    {

        public MapPage(): base()
        {
            SetTemplateDisabledButtonMap();
            InitializeComponent();

            BindingContext = new MapViewModel();

        }
       
    }
}