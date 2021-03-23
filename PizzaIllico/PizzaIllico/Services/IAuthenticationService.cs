using System;
using System.Threading.Tasks;

using PizzaIllico.Models.Authentication;

namespace PizzaIllico.Services
{
    // Login et inscription
    interface IAuthenticationService
    {
        
        Task<AuthenticationLoginResponse> Login(AuthenticationLoginRequest login);

        bool StoreToken<T>(T data, TimeSpan timeSpan);
        T GetToken<T>();
    }
}
