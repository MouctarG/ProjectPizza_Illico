
namespace PizzaIllico.Models.Authentication
{
    class AuthenticationRefreshResponse: Library.Response
    { 
        public Library.AuthenticationToken Data { get; set; }
    }
}
