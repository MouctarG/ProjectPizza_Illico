using PizzaIllico.Models.Library;
using System.Collections.Generic;

namespace PizzaIllico.Models.Pizzeria
{
    class PizzeriaGetAllPizzasResponse: Library.Response, Library.IGetAllResponse<Library.Pizza>
    {
        public ICollection<Library.Pizza> Data { get; set; }

        public List<Pizza> getData()
        {
            return (List<Pizza>)Data;
        }
    }
}
