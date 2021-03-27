
namespace PizzaIllico.Models.Authentication
{
    class AuthenticationPasswordPatchRequest
    {
        private string old_password;
        private string new_password;
        // private string access_token;
        /*
        public string Access_token
        {
            get => access_token;
            set => access_token = value;
        }
        */
        public string New_Password
        {
            get => new_password;
            set => new_password = value;
        }
        public string Old_Password
        {
            get => old_password;
            set => old_password = value;
        }

        public AuthenticationPasswordPatchRequest(string old_password, string new_password)
        {
            this.old_password = old_password;
            this.new_password = new_password;
            // this.access_token = access_token;
        }
    }
}
