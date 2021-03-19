using System.Threading.Tasks;
using PizzaIllico.Models;

namespace PizzaIllico.Services
{
    // services pour un client connecté
    interface IClientService
    {
        Task<RequestResult> ChangePassword(string old_password, string new_password);
        Task<RequestResult> ChangeUserProfile(User new_info);

        // TODO: requete pour l'historique des commandes: Signature de cette méthode à faire plus tard
    }
}
