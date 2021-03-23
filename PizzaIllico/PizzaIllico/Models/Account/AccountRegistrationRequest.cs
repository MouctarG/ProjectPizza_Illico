
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Models.Account
{
    class AccountRegistrationRequest: Library.UserProfile
    {
        private string client_id = Config.CLIENT_ID;
        private string client_secret = Config.CLIENT_SECRET;

        private string password;

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string Client_id { get => client_id; }
        public string Client_secret { get => client_secret; }

        public AccountRegistrationRequest() { }
        public AccountRegistrationRequest(string email, string first_name, string last_name, string phone_number, string password)
            : base(email, first_name, last_name, phone_number)
        {
            this.password = password;
        }
    }

}
