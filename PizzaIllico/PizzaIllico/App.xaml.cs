using System;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico
{
    public partial class App : Application
    {
        public static PizzaManager PizzaManager { get; private set; }
        public App()
        {
            InitializeComponent();
            
            PizzaManager = new PizzaManager (new PizzaService());
            MainPage = new NavigationPage(new MapPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
