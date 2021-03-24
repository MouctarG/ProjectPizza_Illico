using PizzaIllico.Models.Library;
using System.Collections.Generic;

namespace PizzaIllico.Models.Pizzeria
{
    class PizzeriaGetAllPizzasResponse: Library.Response
    {
        public ICollection<Library.Pizza> Data { get; set; }
    }
}
