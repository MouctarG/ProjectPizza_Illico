
namespace PizzaIllico.Models.Library
{
    class Pizza
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Out_of_stock { get; set; }
        public string Image { get; set; }
    }
}
