
namespace PizzaIllico.Models.Library
{
    class UserProfile
    {
        private string email;
        private string first_name;
        private string last_name;
        private string phone_number;

        public string Email
        {
            get => email;
            set => email = value;
        }
        public string First_name
        {
            get => first_name;
            set => first_name = value;
        }
        public string Last_name
        {
            get => last_name;
            set => last_name = value;
        }

        public string Phone_number
        {
            get => phone_number;
            set => phone_number = value;
        }

        public UserProfile(string email, string first_name, string last_name, string phone_number)
        {
            this.email = email;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone_number = phone_number;
        }
        public UserProfile()
        {
            this.email = "";
            this.first_name = "";
            this.last_name = "";
            this.phone_number = "";
        }
    }
}
