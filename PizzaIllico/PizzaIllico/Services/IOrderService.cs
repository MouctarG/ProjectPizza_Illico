using PizzaIllico.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaIllico.Services
{
    interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync(string email);
        void SaveOrderAsync(Order order);
    }
}
