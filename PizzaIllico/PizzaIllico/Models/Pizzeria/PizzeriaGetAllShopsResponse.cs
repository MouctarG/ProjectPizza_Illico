using PizzaIllico.Models.Library;
using System.Collections.Generic;

namespace PizzaIllico.Models.Pizzeria
{
    class PizzeriaGetAllShopsResponse: Library.Response, IGetAllResponse<Library.Pizzeria>
    {
        public ICollection<Library.Pizzeria> Data { get; set; }

        public List<Library.Pizzeria> getData()
        {
            return (List<Library.Pizzeria>)Data;
        }

    }
}
