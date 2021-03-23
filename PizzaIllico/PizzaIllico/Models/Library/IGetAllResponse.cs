using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIllico.Models.Library
{
    interface IGetAllResponse<T>
    {
        List<T> getData();
    }
}
