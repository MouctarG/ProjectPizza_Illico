using Newtonsoft.Json;
using PizzaIllico.Models.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

using PizzaIllico.Models.Pizzeria;
using PizzaIllico.Resources.Config;
using System.IO;
using System.Net.Http;

namespace PizzaIllico.Services
{
    class PizzeriaService : IPizzeriaService
    {
        PizzeriaGetAllShopsResponse _pizzerias;
        PizzeriaGetAllPizzasResponse _pizzas;

        public void RequestPizzeriaList(Action<PizzeriaGetAllShopsResponse> _action)
        {
            _pizzerias = new PizzeriaGetAllShopsResponse();
            _pizzerias.Data = new List<Pizzeria>();

            using (var webclient = new WebClient())
            {
                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    try
                    {
                        string itemsJson = e.Result;

                        PizzeriaGetAllShopsResponse item = JsonConvert.DeserializeObject<PizzeriaGetAllShopsResponse>(itemsJson);

                        Device.BeginInvokeOnMainThread(() => { _action.Invoke(item); });

                    }
                    catch
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _action.Invoke(null);
                        });
                    }
                };

                webclient.DownloadStringAsync(new Uri(Config.URL_SHOPS));
            }
        }


        public void RequestRestaurantPizzaList(Action<ICollection<Pizza>> _action, string restaurant_id)
        {
            _pizzas = new PizzeriaGetAllPizzasResponse();
            _pizzas.Data = new List<Pizza>();

            using (var webclient = new WebClient())
            {
                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    try
                    {
                        string itemsJson = e.Result;

                        PizzeriaGetAllPizzasResponse item = JsonConvert.DeserializeObject<PizzeriaGetAllPizzasResponse>(itemsJson);

                        Device.BeginInvokeOnMainThread(() => { _action.Invoke(item.Data); });

                    }
                    catch
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            _action.Invoke(null);
                        });
                    }
                };

                webclient.DownloadStringAsync(new Uri(Config.Pizzeria_getURI(restaurant_id)));
            }
        }

        public void sortPizzas(Pizzeria pizzeria,  List<Pizza> pizzas, ObservableCollection<Pizza> _desti)
        {
            if (pizzas == null || _desti == null) return;
            pizzas.Sort((p1, p2) =>
            {
                if (p1 == null) return (p2 == null) ? 1 : 0;      // si p2 existe il est plus proche que null
                else if (p2 == null) return 1;                     // p1 plus proche que null
                else
                {
                    double res = p2.Price - p1.Price;
                    if (res == 0) return 0;
                    else return res < 0 ? 1 : -1;

                };
            });

            _desti.Clear();
            foreach (var pizza in pizzas)
            {
                pizza.CurrentPizzeria = pizzeria;
                _desti.Add(pizza);
            }
        }
        public void sortPizzerias(List<Pizzeria> pizzerias, ObservableCollection<Pizzeria> _desti)
        {

            if (pizzerias == null || _desti == null) return;
            pizzerias.Sort((p1, p2) =>
            {
                if (p1 == null) return (p2 == null) ? 1 : 0;      // si p2 existe il est plus proche que null
                else if (p2 == null) return 1;                     // p1 plus proche que null
                else
                {
                    long res = p2.Minutes_per_kilometer - p1.Minutes_per_kilometer;
                    if (res == 0) return 0;
                    else return res < 0 ? 1 : -1;

                };
            });

            _desti.Clear();
           
            foreach (var pizzeria in pizzerias) _desti.Add(pizzeria);
        }
    }
}
