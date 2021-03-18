using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaIllico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionPage : ContentPage
    {
        public InscriptionPage()
        {
            InitializeComponent();
           
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nom.Text) || string.IsNullOrEmpty(nom.Text)
            || string.IsNullOrWhiteSpace(prenom.Text) || string.IsNullOrEmpty(prenom.Text)
            || string.IsNullOrWhiteSpace(mdp.Text) || string.IsNullOrEmpty(mdp.Text)
            || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrEmpty(email.Text))
            {
                
            }
            else
            {
                User user = new User(email.Text,prenom.Text,nom.Text,phone.Text,mdp.Text);
                Inscription(user);

            }
            
          
        }
        private async Task  Inscription(User user)
        {
            if (App.PizzaManager.insription(user).Result)
            {
                await DisplayAlert ("Inscrit", "Votre compte est créer", "OK");
            }
            else
            {
                await DisplayAlert ("Erreur", "Impossible de creer le compte", "OK");
            }
        }
    }
}