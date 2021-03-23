using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Task<GetLoginData> GetTokenLogin(Login login)
        {
            return _service.GetTokenLogin(login);
        }

        public void GetAllPizzaria(Action<List<ItemPizzaria>> action)
        {
             _service.GetAllPizzaria(action);
        }
        public void GetAllPizzaByShop(Action<List<ItemPizza>> action,int id )
        {
            _service.GetAllPizzaByShop(action,id);
        }

        public Task <bool> Insription(UserRegister user)
        {
            return _service.Inscription(user);
        }

        public Task <bool> UpdatePassword(UpdatePassword updatePassword,string token)
        {
            return _service.UpdatePassword(updatePassword,token);
        }

        public void SortPizzarias(List<ItemPizzaria> pizzerias)
        {
            _service.SortPizzarias(pizzerias);
        }
    }
}