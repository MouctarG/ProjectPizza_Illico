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
    public partial class ProfileRegistrationPage : PageLayoutTemplateControl 
    { 
        public ProfileRegistrationPage() : base()
        {
            PageTitle = "Registration";

            InitializeComponent();
            BindingContext = new ProfileRegistrationViewModel();
        }
    }
}