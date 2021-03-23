using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PizzaIllico.Models;

namespace PizzaIllico.Services
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetPizzasAsync(string res);
        Task <bool> Inscription(UserRegister user);
        Task<GetLoginData> GetTokenLogin(Login login);
        void  GetAllPizzaria(Action<List<ItemPizzaria>> action);
        void GetAllPizzaByShop(Action<List<ItemPizza>> action, int id);
        
        Task <bool> UpdatePassword(UpdatePassword updatePassword,string token);
        void SortPizzarias(List<ItemPizzaria> pizzerias);
    }
}