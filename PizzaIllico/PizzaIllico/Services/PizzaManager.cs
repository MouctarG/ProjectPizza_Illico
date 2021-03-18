using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaIllico.Models;

namespace PizzaIllico.Services
{
    public class PizzaManager
    {
        private IPizzaService _service;

        public PizzaManager(IPizzaService pizzaService)
        {
            this._service = pizzaService;
        }

        public Task<GetLoginData> getTokenLogin(Login login)
        {
            return _service.getTokenLogin(login);
        }

        public void getAllPizzaria(Action<List<ItemPizzaria>> action)
        {
             _service.getAllPizzaria(action);
        }
        public void getAllPizzaByShop(Action<List<ItemPizza>> action,int id )
        {
            _service.getAllPizzaByShop(action,id);
        }

    }
}