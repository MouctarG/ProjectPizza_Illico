using System;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Storm.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico
{
    public partial class App : MvvmApplication
    {
        public App() : base(() => new LoginPage(), RegisterServices)
        {
            InitializeComponent();
            
        }

        private static void RegisterServices()
        {
            DependencyService.Register<ILoginService, LoginService>();


        }
    }
}
