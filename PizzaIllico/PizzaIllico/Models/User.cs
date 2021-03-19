using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIllico.Models
{
    class User
    {
        private string email;
        private string first_name;
        private string last_name;
        private string phone_number;
        private string password;

        public string Email => email;

        public string FirstName => first_name;

        public string LastName => last_name;

        public string PhoneNumber => phone_number;

        public string Password => password;

        public User() { }
        public User(string email, string first_name, string last_name, string phone_number, string password)
        {
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone_number = phone_number;
            this.password = password;
        }
    }
}
