using PizzaIllico.Models.Library;
using System.Collections.Generic;

namespace PizzaIllico.Models.Pizzeria
{
    class PizzeriaGetAllShopsResponse: Library.Response
    {
        public ICollection<Library.Pizzeria> Data { get; set; }

    }
}
