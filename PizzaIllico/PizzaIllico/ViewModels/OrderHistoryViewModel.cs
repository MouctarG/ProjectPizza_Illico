using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class OrderHistoryViewModel: PageLayoutViewModel
    {
        public OrderHistoryViewModel()
        {
            FooterButtonBackArrow = new Command(async () => await NavigationService.PopAsync());
        }
        public Command FooterButtonBackArrow { get; }
    }
}
