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
    public partial class ProfileUpdatePage : ProfilePage
    {
        
        public ProfileUpdatePage(): base(PizzaIllico.Resources.Config.EnumPages.PROFILE_UPDATE)
        {
            
        }
    }
}