
namespace PizzaIllico.Models.Library
{
    class Pizzeria
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public long Minutes_per_kilometer { get; set; }

    }
}
