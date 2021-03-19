using PizzaIllico.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaIllico.Services
{
    // service disponible que l'on soit connecté ou non
    interface IPublicService
    {
        Task<RequestResult> RequestPizzariaList(Action<List<Pizzeria>> action);
        Task<RequestResult> RequestRestaurantPizzaList(Action<List<Pizza>> action, int restaurant_id);
    }
}
