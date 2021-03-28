using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PizzaIllico.Models.Library;
using PizzaIllico.Models.Pizzeria;

namespace PizzaIllico.Services
{
    // service disponible que l'on soit connecté ou non
    interface IPizzeriaService
    {
        void RequestPizzeriaList(Action<PizzeriaGetAllShopsResponse> _action);
        // void RequestRestaurantPizzaList(Action<ObservableCollection<Pizza>> _action, int restaurant_id);
        void RequestRestaurantPizzaList(Action<ICollection<Pizza>> _action, string restaurant_id);

        void sortPizzerias(List<Pizzeria>  pizzerias, ObservableCollection<Pizzeria> _pizzerias);

        void sortPizzas(Pizzeria pizzeria, List<Pizza> pizzas, ObservableCollection<Pizza> _pizzas);

    }
}
