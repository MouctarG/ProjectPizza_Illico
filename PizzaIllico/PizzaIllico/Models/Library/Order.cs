using SQLite;
using System;

namespace PizzaIllico.Models.Library
{
    class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        
    }
}
