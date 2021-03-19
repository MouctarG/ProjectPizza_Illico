using PizzaIllico.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.Services
{
    class LoginService : ILoginService
    {

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public LoginService()
        {

            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<LoginOutput> Login(LoginInput login)
        {
            Uri uri = new Uri(Config.URL_LOGIN);
            LoginOutput loginOutput = null;

            try
            {

                string json = JsonSerializer.Serialize<LoginInput>(login, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    //  var jsonString = await response.Content.ReadAsStringAsync();
                    loginOutput = JsonConvert.DeserializeObject<LoginOutput>(contentResponse);
                    loginOutput.Result.Is_success = true;

                    //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else
                {
                    loginOutput = new LoginOutput();
                    loginOutput.Result.Is_success = false;
                    loginOutput.Result.Error_code = ErrorCode.LOGIN_ABORTED;
                    return loginOutput;
                }

            }
            catch (Exception ex)
            {
                if( loginOutput == null ) loginOutput = new LoginOutput();
                loginOutput.Result.Is_success = false;
                loginOutput.Result.Error_code = ErrorCode.LOGIN_ABORTED;
                // Debug.WriteLine(@"\tERROR {0}", ex.Message);

                // Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }

            return loginOutput;
        }

        public async Task<RequestResult> Register(User user)
        {
            
            Uri uri = new Uri(Config.URL_USER_REGISTRATION);
            RequestResult requestResult = new RequestResult();

            try
            {
                string json = JsonSerializer.Serialize<Registration>(new Registration(user));
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    //  var jsonString = await response.Content.ReadAsStringAsync();
                    //loginData=  JsonConvert.DeserializeObject<GetLoginData>(contentResponse);

                    //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    requestResult.Is_success = true;
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else
                {
                    requestResult.Is_success = false;
                    requestResult.Error_code = ErrorCode.REGISTRATION_ABORTED;

                }

            }
            catch (Exception ex)
            {
                requestResult.Is_success = false;
                requestResult.Error_code = ErrorCode.REGISTRATION_ABORTED;
                // Debug.WriteLine(@"\tERROR {0}", ex.Message);

                // Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }
            return requestResult;
        }
    }
}
