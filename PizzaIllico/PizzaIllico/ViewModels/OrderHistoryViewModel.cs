using PizzaIllico.Models.Library;
using PizzaIllico.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);
        }

        public Command FooterButtonBackArrow { get; }
    }
}
