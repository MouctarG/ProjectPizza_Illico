using PizzaIllico.Resources.Config;

namespace PizzaIllico.Models.Authentication
{
    class AuthenticationRefreshRequest
    {
        private string client_id = Config.CLIENT_ID;
        private string client_secret = Config.CLIENT_SECRET;
        private string refresh_token;
        public string Refresh_token 
        { 
            get => refresh_token; 
            set => refresh_token = value; 
        }

        public string Client_id { get => client_id; }
        public string Client_secret { get => client_secret; }

        AuthenticationRefreshRequest(string refresh_token)
        {
            this.refresh_token = refresh_token;
        }
    }
}
