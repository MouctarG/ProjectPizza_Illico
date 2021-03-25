using PizzaIllico.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Storm.Mvvm;

using PizzaIllico.Models.Pizzeria;
using PizzaIllico.Models.Library;
using PizzaIllico.Views;
using PizzaIllico.Resources.Config;

namespace PizzaIllico.ViewModels
{
    class HomeViewModel : PageLayoutViewModel
    {


        // =====================================================================================================
        private bool _isRefreshing;
        private bool _isRunning;
        private Pizzeria _selectedPizerria;

        public bool IsRunning 
        { 
            get => _isRunning; 
            set { SetProperty<bool>(ref _isRunning, value); } 
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { 
                 SetProperty<bool>(ref _isRefreshing, value);
            }

        }
        

        private IPizzeriaService _publicService = DependencyService.Get<IPizzeriaService>();
        private PizzeriaGetAllShopsResponse _pizzerias_response;

        private ObservableCollection<Pizzeria> _pizzerias;

        public ObservableCollection<Pizzeria> Pizzerias { get { return _pizzerias; } }

        public Command RefreshCommand;

        public Pizzeria SelectedPizzeria {
            get => _selectedPizerria;
            set { SetProperty<Pizzeria>(ref _selectedPizerria, value); }
        }

        public Command GoToPizzeriaDetailCommand { get; }

        private async void Go_toPizzeria(object obj)
        {
            if (_selectedPizerria != null)
            {
                
                var pizzeriaPage = new PizzeriaPage();
                Dictionary<string, object> navigationParams = new Dictionary<string, object>()
                {
                    {Config.KEY_PIZZERIA_ID, _selectedPizerria.Id }
                };

                await NavigationService.PushAsync<PizzeriaPage>(navigationParams);
               
            }
        }
        private void Do_refresh(object obj)
        {
            if (_isRefreshing) return;
            _isRefreshing = true;
            _publicService.RequestPizzeriaList((pizzerias) =>
            {
                _publicService.sortPizzerias((List<Pizzeria>)pizzerias.Data, _pizzerias);
            });
            IsRefreshing = false;
        }
        public HomeViewModel()
        {
            _pizzerias = new ObservableCollection<Pizzeria>();

           

            FooterButtonHomeCommand = new Command(() => { });
            FooterButtonLoginCommand = new Command(async () => await NavigationService.PushAsync<LoginPage>());
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>());
            FooterButtonRegistrationCommand = new Command(async ()  => await NavigationService.PushAsync<RegistrationPage>() );


            GoToPizzeriaDetailCommand = new Command(Go_toPizzeria);
            RefreshCommand = new Command(Do_refresh);

            Do_refresh(null);
        }

    }
}
