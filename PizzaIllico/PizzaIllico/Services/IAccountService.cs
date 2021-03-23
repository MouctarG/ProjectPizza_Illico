using System.Threading.Tasks;

using PizzaIllico.Models.Account;
using PizzaIllico.Models.Authentication;

namespace PizzaIllico.Services
{
    interface IAccountService
    {
        Task<AccountRegistrationResponse> Register(AccountRegistrationRequest user);
        Task<AuthenticationPasswordPatchResponse> ChangePassword(AuthenticationPasswordPatchRequest patch_info);
        Task<AccountInformationPatchResponse> ChangeUserProfile(AccountInformationPatchRequest new_info);
    }
}
