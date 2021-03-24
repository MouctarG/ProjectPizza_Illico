using PizzaIllico.Models.Library;
using PizzaIllico.Services;
using Storm.Mvvm;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PizzaIllico.ViewModels
{

    class MapViewModel : ViewModelBase
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
