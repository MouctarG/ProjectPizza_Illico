using Storm.Mvvm;
using Xamarin.Forms;

using PizzaIllico.Services;
using PizzaIllico.Views;
using System;
using PizzaIllico.Controls;

namespace PizzaIllico
{
    public partial class App : MvvmApplication
    {

        public App() : base(() => new NavigationPage(new HomePage()), () => RegisterServices() )
        {
            InitializeComponent();
            
        }

        private static void RegisterServices()
        {
            DependencyService.Register<IAuthenticationService, AuthenticationService>();
            DependencyService.Register<IAccountService, AccountService>();
            DependencyService.Register<IPizzeriaService, PizzeriaService>();
        }

    }
}
