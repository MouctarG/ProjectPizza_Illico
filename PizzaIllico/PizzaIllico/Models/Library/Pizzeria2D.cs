using System;
using Xamarin.Forms.Maps;

namespace PizzaIllico.Models.Library
{
    class Pizzeria2D
    {
        private string _address;
        private string _name;
        private Position _position2D;
        public Position Position2D { get => _position2D; set => _position2D = value; }
        public string Name { get => _name; set => _name = value; }

        public string Address { get => _address; set => _address = value; }

       
        public Pizzeria2D(Pizzeria p)
        {
            _name = p.Name;
            _address = p.Address;
            _position2D = new Position(Convert.ToDouble(p.Latitude), Convert.ToDouble(p.Longitude));
        }

    }
}
