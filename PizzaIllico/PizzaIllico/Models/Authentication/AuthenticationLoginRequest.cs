
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Models.Authentication
{
    class AuthenticationLoginRequest
    {
        private string login;
        private string password;
        private string client_id = Config.CLIENT_ID;
        private string client_secret = Config.CLIENT_SECRET;
        public string Login 
        { 
            get => login; 
            set => login = value; 
        }
        public string Password 
        { 
            get => password; 
            set => password = value; 
        }

        public string Client_id { get => client_id; }
        public string Client_secret { get => client_secret; }


        public AuthenticationLoginRequest(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
