using PizzaIllico.Models;
using System.Threading.Tasks;

namespace PizzaIllico.Services
{
    // Login et inscription
    interface ILoginService
    {
        Task<RequestResult> Register(User user);
        Task<LoginOutput> Login(LoginInput login);
    }
}
