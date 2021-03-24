
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Models.Library
{
    class Pizza
    {
        private string _pizzeria_id;
        private string _pizza_id;

        public string Id { get => _pizza_id; set => _pizza_id = value; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Out_of_stock { get; set; }

        public string Pizzeria_id { get => _pizzeria_id; set => _pizzeria_id = value; }
        public string Image { get => Config.PizzeriaPizzaImage_getURI(_pizzeria_id, _pizza_id);  }
    }
}
