using System;
using PizzaIllico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPizzaPage : ContentPage
    {
        public ItemPizza pizza;
    
        public DetailsPizzaPage(ItemPizza pizza)
        {
            this.pizza = pizza;
            InitializeComponent();

            name.Text = pizza.name;
            description.Text = pizza.description;
            price.Text = pizza.price + " $";
            image.Source = pizza.imageUrl;

        }

        private void Button_OnClicked_Commander(object sender, EventArgs e)
        {
            
        }

        private void Button_OnClicked_AddPanier(object sender, EventArgs e)
        {
          
        }
    }
}