using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzaIllico.Config;
using PizzaIllico.Models;
using Xamarin.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PizzaIllico.Services
{
    public class PizzaService : IPizzaService
    {

        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public PizzaService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public List<Pizza> pizzas { get; private set; }

        public Task<List<Pizza>> GetPizzasAsync(string res)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Inscription(UserRegister user)
        {
            Uri uri = new Uri(AllUrl.URL_USER_INSCRIPTION);

            try
            {

                string json = JsonSerializer.Serialize<UserRegister>(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                
                Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);

                return false;
            }
            return false;
       
        }

        public async Task<GetLoginData> GetTokenLogin(Login login)
        {
            Uri uri = new Uri(AllUrl.URL_LOGIN);
            GetLoginData loginData = null;

            try
            {

                string json = JsonSerializer.Serialize<Login>(login, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                  //  var jsonString = await response.Content.ReadAsStringAsync();
                    loginData=  JsonConvert.DeserializeObject<GetLoginData>(contentResponse);

                 //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                
                Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }

            return loginData;
        }

        public void GetAllPizzaria(Action<List<ItemPizzaria>> action)
        {
       
            
            List<ItemPizzaria> itemPizzarias = new List<ItemPizzaria>();

            using (var webclient = new WebClient())
            {

                // Thread Main (UI)
                //pizzasJson = webclient.DownloadString(URL);

                Console.WriteLine("ETAPE 2");

                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    //
                    Console.WriteLine("ETAPE 5");

                    //Console.WriteLine("Données téléchargées: " + e.Result);
                    try
                    {
                        string pizzasJson = e.Result;

                        Pizzaria pizzaria = JsonConvert.DeserializeObject<Pizzaria>(pizzasJson);

                        //

                        Device.BeginInvokeOnMainThread(() => { action.Invoke(pizzaria.data); });

                    }
                    catch (Exception ex)
                    {
                        // Thread réseau
                        Device.BeginInvokeOnMainThread(() =>
                        {
                           // DisplayAlert("Erreur", "Une erreur réseau s'est produite: " + ex.Message, "OK");
                            action.Invoke(null);
                        });
                    }

                };

             
                webclient.DownloadStringAsync(new Uri(AllUrl.URL_SHOPS));
            }

        }

        public void GetAllPizzaByShop(Action<List<ItemPizza>> action, int id)
        {

            using (var webclient = new WebClient())
            {
                Console.WriteLine("ETAPE 2");

                webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
                    //
                    Console.WriteLine("ETAPE 5");

                    //Console.WriteLine("Données téléchargées: " + e.Result);
                    try
                    {
                        string pizzasJson = e.Result;

                        Pizza pizza = JsonConvert.DeserializeObject<Pizza>(pizzasJson);
                        

                        Device.BeginInvokeOnMainThread(() => { action.Invoke(pizza.data); });

                    }
                    catch (Exception ex)
                    {
                        // Thread réseau
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            // DisplayAlert("Erreur", "Une erreur réseau s'est produite: " + ex.Message, "OK");
                            action.Invoke(null);
                        });
                    }

                };
                webclient.DownloadStringAsync(new Uri(AllUrl.URL_SHOPS+"/"+id+"/pizzas"));
            }
        }

        public async Task<bool>  UpdatePassword(UpdatePassword updatePassword,string token)
        {
            Uri uri = new Uri(AllUrl.URL_UPDATE_PASSWORD);

            try
            {
                
                string json = JsonSerializer.Serialize<UpdatePassword>(updatePassword);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = null;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
               
               var method = new HttpMethod("PATCH");

               var request = new HttpRequestMessage(method, uri) {
                   Content = new StringContent(
                       JsonConvert.SerializeObject(updatePassword),
                       Encoding.UTF8, "application/json")
               };
                response = await client.SendAsync(request);
          
                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode) return true;


            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                
                Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);

                return false;
            }
            return false;

        }


        public void SortPizzarias(List<ItemPizzaria> pizzerias)
        {
            if (pizzerias == null ) return;
            pizzerias.Sort((p1, p2) =>
            {
                if (p1 == null) return (p2 == null) ? 1 : 0;      // si p2 existe il est plus proche que null
                else if (p2 == null) return 1;                     // p1 plus proche que null
                else
                {
                    long res = p2.minutes_per_kilometer - p1.minutes_per_kilometer;
                    if (res == 0) return 0;
                    else return res < 0 ? 1 : -1;

                };
            });

        }
    }

}

