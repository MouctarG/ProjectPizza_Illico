using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaIllico.Config;
using PizzaIllico.Models;
using PizzaIllico.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PizzaIllico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListePizzaPage : ContentPage
    {
        private PizzaManager pizzaManager;
        public ListePizzaPage(int id)
        {
            InitializeComponent();
            
            pizzaManager = new PizzaManager (new PizzaService());
            
            listView.RefreshCommand = new Command((obj) =>
            {
              
                pizzaManager.getAllPizzaByShop((pizzarias)=>
                {
                    List<ItemPizza> list = new List<ItemPizza>();
                    foreach (var pz in pizzarias)
                    {
                        pz.imageUrl = AllUrl.URL_SHOPS +"/"+ id+"/pizzas/"+pz.id+ "/image";
                        list.Add(pz);
                    }
                    listView.ItemsSource = list;
                    listView.IsRefreshing = false;
                },id);
            });

            listView.IsVisible = false;
            waitLayout.IsVisible = true;
            pizzaManager.getAllPizzaByShop(pizzarias =>
            {
                List<ItemPizza> list = new List<ItemPizza>();
                foreach (var pz in pizzarias)
                {
                    pz.imageUrl = AllUrl.URL_SHOPS +"/"+ id +"/pizzas/"+pz.id+ "/image";
                    list.Add(pz);
                }
                listView.ItemsSource = list;

                listView.IsVisible = true;
                waitLayout.IsVisible = false;
                
                listView.ItemSelected += (sender, e) =>
                {
                    if (listView.SelectedItem != null)
                    {
                        ItemPizza itemPizza = listView.SelectedItem as ItemPizza;
                  
                        Navigation.PushAsync(new DetailsPizzaPage((itemPizza)));
                    
                    }
                };

            },id);
            
          

        }
    }
}