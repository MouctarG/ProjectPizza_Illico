using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PizzaIllico.Models.Library
{
    class OrderDetail: INotifyPropertyChanged
    {

        private string title;
        private string description;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title 
        { 
            get => title;
            set
            {
                title = value;
                var args = new PropertyChangedEventArgs(nameof(Title));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string Description
        {
            get => description;
            set
            {
                title = value;
                var args = new PropertyChangedEventArgs(nameof(Description));
                PropertyChanged?.Invoke(this, args);
            }
        }
        
        public OrderDetail(Order order)
        {
            title = order.Quantity + " pizzas;  " + order.Date + " for " + order.Price + " €";
            description = order.Description;
        }
        public OrderDetail() {}

    }
}
