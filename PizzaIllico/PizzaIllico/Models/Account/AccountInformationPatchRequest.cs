
namespace PizzaIllico.Models.Account
{
    class AccountInformationPatchRequest: Library.UserProfile { 

        private string access_token;

        public string Access_token
        {
            get => access_token;
            set => access_token = value;
        }

        public AccountInformationPatchRequest(string email, string first_name, string last_name, string phone_number,  string access_token)
            : base(email, first_name, last_name, phone_number)
        {
            this.access_token = access_token;
        }

    }
}
