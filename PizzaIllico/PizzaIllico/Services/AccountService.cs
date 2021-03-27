using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PizzaIllico.Models.Account;
using PizzaIllico.Models.Authentication;
using System.Net.Http.Headers;
using PizzaIllico.Resources.Config;
using Newtonsoft.Json;

namespace PizzaIllico.Services
{
    class AccountService: IAccountService
    {
        HttpClient _client = new HttpClient();

        // TODO
        public async Task<AuthenticationPasswordPatchResponse> ChangePassword(AuthenticationPasswordPatchRequest patch_info, string access_token)
        {
            Uri uri = new Uri(Config.URL_UPDATE_PASSWORD);
            AuthenticationPasswordPatchResponse requestResult = null;

            try
            {  
                HttpResponseMessage response = null;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


               var requestMethod = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(requestMethod, uri)
                {
                    Content = new StringContent(
                                Newtonsoft.Json.JsonConvert.SerializeObject(patch_info), Encoding.UTF8, "application/json"
                              )
                };

               response = await _client.SendAsync(request);

                string contentResponse = await response.Content.ReadAsStringAsync();

                requestResult = JsonConvert.DeserializeObject<AuthenticationPasswordPatchResponse>(contentResponse);
               
            }
            catch (Exception ex)
            {
                if (requestResult == null) requestResult = new AuthenticationPasswordPatchResponse();
                requestResult.Is_success = false;
                requestResult.Error_message = ex.Message;
            }
            return requestResult;
        }

        public async Task<AccountInformationPatchResponse> ChangeUserProfile(AccountInformationPatchRequest new_info, string access_token)
        {
            Uri uri = new Uri(Config.URL_UPDATE_PROFILE);
            AccountInformationPatchResponse requestResult = null;

            try
            {
                HttpResponseMessage response = null;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);


                var requestMethod = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(requestMethod, uri)
                {
                    Content = new StringContent(
                                Newtonsoft.Json.JsonConvert.SerializeObject(new_info), Encoding.UTF8, "application/json"
                              )
                };

                response = await _client.SendAsync(request);

                string contentResponse = await response.Content.ReadAsStringAsync();

                requestResult = JsonConvert.DeserializeObject<AccountInformationPatchResponse>(contentResponse);

            }
            catch (Exception ex)
            {
                if (requestResult == null) requestResult = new AccountInformationPatchResponse();
                requestResult.Is_success = false;
                requestResult.Error_message = ex.Message;
            }
            return requestResult;
        }

        public async Task<AccountRegistrationResponse> Register(AccountRegistrationRequest user)
        {

            Uri uri = new Uri(Config.URL_USER_REGISTRATION);
            AccountRegistrationResponse requestResult = null;

            try
            {
                HttpResponseMessage response = null;

                var requestMethod = new HttpMethod("POST");
                var request = new HttpRequestMessage(requestMethod, uri)
                {
                    Content = new StringContent(
                                Newtonsoft.Json.JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"
                              )
                };


                response = await _client.SendAsync(request);

                string contentResponse = await response.Content.ReadAsStringAsync();

                requestResult = JsonConvert.DeserializeObject<AccountRegistrationResponse>(contentResponse);

            }
            catch (Exception ex)
            {
                if (requestResult == null) requestResult = new AccountRegistrationResponse();
                requestResult.Is_success = false;
                requestResult.Error_message = ex.Message;
            }
            return requestResult;
        }
    }
}
