using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PizzaIllico.Config;
using PizzaIllico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.Json;
using PizzaIllico.Services;


namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

         private  async void Button_OnClicked_Login(object sender, EventArgs e)
        {
            Login login = new Login("paul@123.fr", "123456");
    
            GetLoginData loginData=  await App.PizzaManager.getTokenLogin(login);

               await DisplayAlert ("Alert", loginData.data.access_token, "OK");


        }
        
        private void Button_OnClicked_Inscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionPage());
        }
    
        
    }
    
    
}