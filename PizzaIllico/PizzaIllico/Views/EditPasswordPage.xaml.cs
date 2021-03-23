using System;
using PizzaIllico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPasswordPage : ContentPage
    {
        public EditPasswordPage()
        {
            InitializeComponent();
            waitLayout.IsVisible = false;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            UpdatePassword();
        }

        private  async  void UpdatePassword()
        {
            if (string.IsNullOrWhiteSpace(old_password.Text) || string.IsNullOrEmpty(old_password.Text)
                                                             || string.IsNullOrWhiteSpace(new_password.Text) || string.IsNullOrEmpty(new_password.Text))
            {
                await DisplayAlert ("Erreur", "Les deux champs sont obligatiore", "OK");
            }
            else
            {
                UpdatePassword updatePassword = new UpdatePassword(old_password.Text, new_password.Text);
                string token = "967d1f0984ef4984b5ee4c8d3f3b6bef@";
                waitLayout.IsVisible = true;
               bool b =await App.PizzaManager.UpdatePassword(updatePassword, token);
             
               if (b)
               {
                   new_password.Text = "";
                   old_password.Text = "";
                   waitLayout.IsVisible = false;
                   await DisplayAlert ("Operation effectuée", "Votre mot de passe est bien modifier", "OK");
                   Navigation.PushAsync(new MainPage());
               }
               else
               {
                   await DisplayAlert ("Erreur", "Veuillez réessayer", "OK");
                   waitLayout.IsVisible = false;
                   new_password.Text = "";
                   old_password.Text = "";
               }
            }
        }
    }
}