using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaIllico.Models;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Xamarin.Forms;


namespace PizzaIllico
{
    public partial class MainPage : ContentPage
    {
        private PizzaManager pizzaManager;
        
        
        public MainPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            pizzaManager = new PizzaManager (new PizzaService());
            
            listView.RefreshCommand = new Command((obj) =>
            {
           
                pizzaManager.getAllPizzaria((pizzarias) =>
                {
                    listView.ItemsSource = pizzarias;
                    listView.IsRefreshing = false;
                });
            });

            listView.IsVisible = false;
            waitLayout.IsVisible = true;
        pizzaManager.getAllPizzaria(pizzarias =>
        {
            listView.ItemsSource = pizzarias;

            listView.IsVisible = true;
            waitLayout.IsVisible = false;
            listView.ItemSelected += (sender, e) =>
            {
                if (listView.SelectedItem != null)
                {
                    ItemPizzaria itemPizza = listView.SelectedItem as ItemPizzaria;
                  
                    Navigation.PushAsync(new ListePizzaPage((itemPizza.id)));
                    
                }
            };

        });

        }


    }
}
