
using PizzaIllico.Resources.Config;
using System.ComponentModel;
using Xamarin.Forms;

namespace PizzaIllico.Models.Library
{
    class Pizza: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Pizzeria _current_pizzeria;
        private string _pizza_id;
        private double price;

        private int quantity;

        private bool is_selected = false;
        private Color pizza_background_color = Color.AliceBlue;

        public string Id { get => _pizza_id; set => _pizza_id = value; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get => price; set => price = value; }
        public bool Out_of_stock { get; set; }

        public Pizzeria CurrentPizzeria { get => _current_pizzeria; set => _current_pizzeria = value; }
        public string Image { get => Config.PizzeriaPizzaImage_getURI(_current_pizzeria.Id, _pizza_id);  }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                var args = new PropertyChangedEventArgs(nameof(QuantityTag));
                PropertyChanged?.Invoke(this, args);
                args = new PropertyChangedEventArgs(nameof(TotalPriceTag));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string PriceTag
        {
            get => price + " €";
        }
        public string TotalPriceTag
        {
            get => price * quantity + " €";
        }
        public string QuantityTag
        {
            get
            {
                if (quantity < 10) return "0" + quantity;
                return "" + quantity;
            }
        }
        public bool IsSelected
        {
            get => is_selected;
            set => is_selected = value;
        }

        public Color PizzaBackgroundColor
        {
            get => pizza_background_color;

            set
            {
                pizza_background_color = value;
                var args = new PropertyChangedEventArgs(nameof(PizzaBackgroundColor));
                PropertyChanged?.Invoke(this, args);
            }
    }
        public bool ToggleSelected()
        {
            is_selected = !is_selected;
            if (is_selected)
            {
                if (quantity == 0) Quantity = 1;
                PizzaBackgroundColor = Color.Orange;

            }
            else
            {
                if (quantity > 0) Quantity = 0;
                PizzaBackgroundColor = Color.AliceBlue;
            }
            return is_selected;
        }
    }
}
