using PizzaIllico.Controls;
using PizzaIllico.ViewModels;

using Xamarin.Forms.Xaml;



namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileUpdatePage : PageLayoutTemplateControl
    {

        public ProfileUpdatePage()
        {
            PageTitle = "Profile update";

            InitializeComponent();
            BindingContext = new ProfileUpdateViewModel();

        }
    }
}