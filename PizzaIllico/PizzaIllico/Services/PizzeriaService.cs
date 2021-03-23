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

namespace PizzaIllico.Services
{
    class PizzeriaService : IPizzeriaService
    {
        PizzeriaGetAllShopsResponse _pizzerias;

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
                    catch (Exception ex)
                    {
                        // Thread réseau
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            // DisplayAlert("Erreur", "Une erreur réseau s'est produite: " + ex.Message, "OK");
                            _action.Invoke(null);
                        });
                    }
                };

                webclient.DownloadStringAsync(new Uri(Config.URL_SHOPS));
            }
        }


        public void RequestRestaurantPizzaList(Action<ObservableCollection<Pizza>> _action, int restaurant_id)
        {
            throw new NotImplementedException();
        }

        public void sortPizzerias(List<Pizzeria> pizzerias, ObservableCollection<Pizzeria> _desti)
        {

            if (pizzerias == null || _desti == null) return;
            pizzerias.Sort((p1, p2) =>
            {
                if (p1 == null ) return ( p2 == null) ? 1 : 0;      // si p2 existe il est plus proche que null
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
