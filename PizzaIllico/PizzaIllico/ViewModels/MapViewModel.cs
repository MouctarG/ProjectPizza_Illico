using PizzaIllico.Models.Library;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PizzaIllico.ViewModels
{

    class MapViewModel : PageLayoutViewModel
    {
        private static IPizzeriaService _pizzeriaService = DependencyService.Get<IPizzeriaService>();
        private Collection<Pizzeria2D> _pizzerias = new Collection<Pizzeria2D>();

        public Collection<Pizzeria2D> Pizzerias
        {
            get => _pizzerias;
            set => _pizzerias = value;
        }

        public MapViewModel()
        {

            FooterButtonMapCommand = new Command(() => { });

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));

       
            Do_refresh(null);
           
        }
        private void Do_refresh(object obj)
        {
            _pizzeriaService.RequestPizzeriaList((pizzerias) =>
            {

                foreach (var item in pizzerias.Data)
                {
                    Position position = new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude));

                    _pizzerias.Add(new Pizzeria2D(item));


                }

            });
        }
        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }
    }
}
