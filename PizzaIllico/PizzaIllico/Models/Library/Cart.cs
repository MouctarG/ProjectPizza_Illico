using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PizzaIllico.Models.Library
{
    class Cart: INotifyPropertyChanged
    {
        private Collection<Pizza> pizzas = new Collection<Pizza>();
        public Collection<Pizza> Pizzas
        {
            get => pizzas;
            set
            {
                pizzas = value;
                var args = new PropertyChangedEventArgs(nameof(Pizzas));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            string str = "";
            foreach(Pizza item in pizzas)
            {
                str += item.Name + " [ Quantity: " + item.QuantityTag + "; Price: " + item.TotalPriceTag + "]; ";
            }
            return str;
        }

        public void RemoveUnselectedPizzas()
        {
            foreach(Pizza item in pizzas)
            {
                if (item.Quantity == 0) pizzas.Remove(item);
            }
        }
    }
}
