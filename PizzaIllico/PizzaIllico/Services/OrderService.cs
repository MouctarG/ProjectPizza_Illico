using PizzaIllico.Models.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PizzaIllico.Services
{
    class OrderService: IOrderService
    {
        static Database _database;

        public OrderService()
        {
            if (_database == null)
            {
                _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "orders.db3"));
            }
        }
        public static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "orders.db3"));
                }
                return _database;
            }
        }

        public Task<List<Order>> GetOrdersAsync(string email)
        {
            return Database.GetOrdersAsync(email);
        }

        public async void SaveOrderAsync(Order order)
        {
            await Database.SaveOrderAsync(order);
        }
    }
}
