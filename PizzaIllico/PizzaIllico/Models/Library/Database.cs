using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace PizzaIllico.Models.Library
{
    class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Order>().Wait();
        }

        public async Task<List<Order>> GetOrdersAsync(string email)
        {
            List<Order> orders = await _database.Table<Order>().ToListAsync();

            List<Order> result = new List<Order>();
            foreach (Order order in orders)
            {
                if( order.Email == email) result.Add(order);
            }

            return result;

        }

        public Task<int> SaveOrderAsync(Order order)
        {
            return _database.InsertAsync(order);
        }
    }
}
