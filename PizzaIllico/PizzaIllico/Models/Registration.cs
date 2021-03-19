using PizzaIllico.Resources.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaIllico.Models
{
    
    class Registration
    {
        private string client_id = Config.CLIENT_ID;
        private string client_secret = Config.CLIENT_SECRET;

        private string email;
        private string first_name;
        private string last_name;
        private string phone_number;
        private string password;

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string FirstName
        {
            get => first_name;
            set => first_name = value;
        }

        public string LastName
        {
            get => last_name;
            set => last_name = value;
        }

        public string PhoneNumber
        {
            get => phone_number;
            set => phone_number = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public Registration() { }
        public Registration(User user)
        {
            client_id = user.Email;
            first_name = user.FirstName;
            last_name = user.LastName;
            phone_number = user.PhoneNumber;
            password = user.Password;
        }
    }

}
