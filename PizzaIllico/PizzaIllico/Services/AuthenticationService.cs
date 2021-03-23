using MonkeyCache;
using MonkeyCache.LiteDB;
using Newtonsoft.Json;
using PizzaIllico.Models.Authentication;
using PizzaIllico.Resources.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaIllico.Services
{
    class AuthenticationService : IAuthenticationService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public AuthenticationService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            try { BarrelUtils.SetBaseCachePath(Config.APP_CACHE_BASE_PATH); }
            catch { }
        }
        public T Get<T>(string url_key)
        {
            Barrel.ApplicationId = Config.APP_CACHE_ID;
            Barrel.EncryptionKey = Config.APP_CACHE_ENCRYPTION_KEY;

            DateTime? stored_expiration_date = Barrel.Current.GetExpiration(url_key);

            if (stored_expiration_date == null || stored_expiration_date < DateTime.UtcNow) return default(T);
            else
            {
                return Task.FromResult(Barrel.Current.Get<T>(url_key)).Result;
            }
        }
        public T GetToken<T>()
        {
            return this.Get<T>(Config.APP_CACHE_TOKEN_KEY);
        }

        public bool WriteToCache<T>(string url_key, T data, TimeSpan timeSpan)
        {

            Barrel.ApplicationId = Config.APP_CACHE_ID;
            Barrel.EncryptionKey = Config.APP_CACHE_ENCRYPTION_KEY;

            string[] keys = { url_key };
            Barrel.Current.Empty(keys);

            DateTime input_expiration_date;

            try
            {
                input_expiration_date = DateTime.UtcNow.Add(timeSpan);
            }
            catch
            {
                if (timeSpan.Milliseconds < 0) input_expiration_date = DateTime.MinValue;
                else input_expiration_date = DateTime.MaxValue;
            }

            if (input_expiration_date < DateTime.UtcNow) return false;

            Barrel.Current.Add<T>(url_key, data, timeSpan);

            return true;
        }


        public bool StoreToken<T>(T data, TimeSpan timeSpan)
        {
            return this.WriteToCache<T>(Config.APP_CACHE_TOKEN_KEY, data, timeSpan);
        }


        public async Task<AuthenticationLoginResponse> Login(AuthenticationLoginRequest login)
        {
            Uri uri = new Uri(Config.URL_LOGIN);
            AuthenticationLoginResponse loginOutput = null;

            try
            {

                string json = System.Text.Json.JsonSerializer.Serialize<AuthenticationLoginRequest>(login, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    //  var jsonString = await response.Content.ReadAsStringAsync();
                    loginOutput = JsonConvert.DeserializeObject<AuthenticationLoginResponse>(contentResponse);
                    // loginOutput.Result.Is_success = true;

                    //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    // Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else
                {
                    loginOutput = new AuthenticationLoginResponse();
                    // loginOutput.Result.Is_success = false;
                    // loginOutput.Result.Error_code = ErrorCode.LOGIN_ABORTED;
                    return loginOutput;
                }

            }
            catch (Exception ex)
            {
                if (loginOutput == null) loginOutput = new AuthenticationLoginResponse();
                loginOutput.Error_message = ex.Message;

                // loginOutput.Result.Is_success = false;
                // loginOutput.Result.Error_code = ErrorCode.LOGIN_ABORTED;
                // Debug.WriteLine(@"\tERROR {0}", ex.Message);

                // Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }

            return loginOutput;
        }


    }
}
