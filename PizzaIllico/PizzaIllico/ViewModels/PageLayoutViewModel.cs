using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class PageLayoutViewModel : ViewModelBase
    {

        public Command FooterButtonHomeCommand
        { get; set; }
        public Command FooterButtonLoginCommand { get; set; }
        public Command FooterButtonRegistrationCommand { get; set; }
        public Command FooterButtonMapCommand { get; set; }

    }
}
