using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using PizzaIllico.Models.Account;
using PizzaIllico.Models.Authentication;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Services
{
    class AccountService: IAccountService
    {
        HttpClient _client;

        // TODO
        public Task<AuthenticationPasswordPatchResponse> ChangePassword(AuthenticationPasswordPatchRequest patch_info)
        {
            throw new NotImplementedException();
        }

        // TODO
        public Task<AccountInformationPatchResponse> ChangeUserProfile(AccountInformationPatchRequest new_info)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountRegistrationResponse> Register(AccountRegistrationRequest user)
        {

            Uri uri = new Uri(Config.URL_USER_REGISTRATION);
            AccountRegistrationResponse requestResult = null;

            try
            {
                string json = JsonSerializer.Serialize<AccountRegistrationRequest>(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    //  var jsonString = await response.Content.ReadAsStringAsync();
                    //loginData=  JsonConvert.DeserializeObject<GetLoginData>(contentResponse);

                    //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    requestResult = JsonSerializer.Deserialize<AccountRegistrationResponse>(contentResponse);
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else
                {
                    requestResult = new AccountRegistrationResponse();
                    requestResult.Is_success = false;

                }

            }
            catch (Exception ex)
            {
                if (requestResult == null) requestResult = new AccountRegistrationResponse();
                requestResult.Is_success = false;
                requestResult.Error_message = ex.Message;
                // Debug.WriteLine(@"\tERROR {0}", ex.Message);

                // Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }
            return requestResult;
        }
    }
}
