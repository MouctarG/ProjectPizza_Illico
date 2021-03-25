using PizzaIllico.Models.Library;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Storm.Mvvm;
using System;
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

            // FooterButtonMapIsEnabled = false;

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>());
            FooterButtonLoginCommand = new Command(async () => await NavigationService.PushAsync<LoginPage>());
            FooterButtonMapCommand = new Command(() => { });
            FooterButtonRegistrationCommand = new Command(async () => await NavigationService.PushAsync<RegistrationPage>());

            _pizzeriaService.RequestPizzeriaList((pizzerias) =>
            {

                foreach (var item in pizzerias.Data)
                {
                    Position position = new Position(Convert.ToDouble(item.Latitude), Convert.ToDouble(item.Longitude));

                    _pizzerias.Add(new Pizzeria2D(item));
                    

                }

            });
        }
    }
}
