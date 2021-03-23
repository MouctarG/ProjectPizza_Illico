using System;
using PizzaIllico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PizzaIllico.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

         private  async void Button_OnClicked_Login(object sender, EventArgs e)
        {
            Login login = new Login("paul@123.fr", "123456");
    
            GetLoginData loginData=  await App.PizzaManager.GetTokenLogin(login);

               await DisplayAlert ("Alert", loginData.data.access_token, "OK");


        }
        
        private void Button_OnClicked_Inscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionPage());
        }
    
        
    }
    
    
}