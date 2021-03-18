using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
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

        public async Task inscription(User user)
        {
            Uri uri = new Uri(AllUrl.URL_USER_INSCRIPTION);

            try
            {

                string json = JsonSerializer.Serialize<User>(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                string contentResponse = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    //  var jsonString = await response.Content.ReadAsStringAsync();
                    //loginData=  JsonConvert.DeserializeObject<GetLoginData>(contentResponse);

                    //    = JsonSerializer.Deserialize<GetLoginData>(response.);
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                //else return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                
                Debug.WriteLine("IMPOSSIBLE Connect", ex.Message);
            }

       
        }

        public async Task<GetLoginData> getTokenLogin(Login login)
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

        public void getAllPizzaria(Action<List<ItemPizzaria>> action)
        {
            /**
            List<ItemPizzaria> itemPizzarias = new List<ItemPizzaria>();

            Uri uri = new Uri(string.Format(AllUrl.URL_SHOPS));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Pizzaria pizzaria =  JsonConvert.DeserializeObject<Pizzaria>(content);
                    itemPizzarias = pizzaria.data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

      

            return itemPizzarias;
            **/
            
            
            
            
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

                Console.WriteLine("ETAPE 3");

                webclient.DownloadStringAsync(new Uri(AllUrl.URL_SHOPS));
            }

        }

        public void getAllPizzaByShop(Action<List<ItemPizza>> action, int id)
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
    }
    
}

