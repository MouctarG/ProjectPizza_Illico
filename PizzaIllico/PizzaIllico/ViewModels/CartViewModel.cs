using PizzaIllico.Models.Library;
using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class CartViewModel : PageLayoutViewModel
    {
        private int total_quantity;
        private double total_price;
        private string order_summary;

        public string OrderSummary
        {
            get => order_summary;
            set
            {
                SetProperty(ref order_summary, value);
            }
        }

        public int TotalQuantity {
            get => total_quantity;
            set
            {
                SetProperty(ref total_quantity, value);
            }
        }
        public double TotalPrice
        {
            get => total_price;
            set
            {
                SetProperty(ref total_price, value);
            }
        }
        public CartViewModel()
        {


            FooterButtonOrder = new Command(Do_order);

            FooterButtonBackArrow = new Command(async () => await NavigationService.PopAsync());

        }
        private async void Do_order()
        {
            if (is_logged_out)
            {
                await Application.Current.MainPage.DisplayAlert("Information", "Please Login first", "OK");
                await NavigationService.PopAsync();
            }
            else
            {
               // TODO store it in the database; msg ok; popasync

            }
        }
        public Command FooterButtonOrder
        {
            get;
        }
        public Command FooterButtonBackArrow
        {
            get;
        }
        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
            Do_refresh(null);
        }

        ObservableCollection<Pizza> _pizzas = new ObservableCollection<Pizza>();
        public ObservableCollection<Pizza> Pizzas { get { return _pizzas; } }
        private void Do_refresh(object obj)
        {

            int total_quantity = 0;
            int quantity;
            double total_price = 0;
            _pizzas.Clear();
            foreach(Pizza item in CurrentCart.Pizzas)
            {
                quantity = item.Quantity;
                if (quantity > 0)
                {
                    _pizzas.Add(item);
                    total_quantity += quantity;
                    total_price += quantity * item.Price;
                }
            }
            TotalPrice = total_price;
            TotalQuantity = total_quantity;
            OrderSummary = total_quantity + " pizzas [ " + total_price + "  ]";

        }
    }
}
