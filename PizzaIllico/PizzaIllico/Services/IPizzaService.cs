using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PizzaIllico.Models;

namespace PizzaIllico.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetPizzasAsync(string res);
        Task inscription(User user);
        Task<GetLoginData> getTokenLogin(Login login);
        void  getAllPizzaria(Action<List<ItemPizzaria>> action);
        void  getAllPizzaByShop(Action<List<ItemPizza>> action,int id);
    }
}