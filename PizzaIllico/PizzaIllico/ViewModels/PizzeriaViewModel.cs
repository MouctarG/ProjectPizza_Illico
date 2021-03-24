using PizzaIllico.Models.Library;
using PizzaIllico.Models.Pizzeria;
using PizzaIllico.Resources.Config;
using PizzaIllico.Services;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class PizzeriaViewModel : ViewModelBase
    {
        private string _restaurant_id;

        private bool _isRefreshing;
        private bool _isRunning;
        private Pizza _selectedPizza;

        private IPizzeriaService _publicService = DependencyService.Get<IPizzeriaService>();
        private PizzeriaGetAllPizzasResponse _pizzas_response;

        private ObservableCollection<Pizza> _pizzas = new ObservableCollection<Pizza>();

        private async void Go_toPizzaDetail(object obj)
        {
            if (_selectedPizza != null)
            {
               // TODO

            }
        }

        private void Do_refresh(object obj)
        {
            if (_isRefreshing) return;
            _isRefreshing = true;
            _publicService.RequestRestaurantPizzaList((pizzas) =>
            {
                _publicService.sortPizzas(Id, (List<Pizza>)pizzas, _pizzas);
            }, Id);

            IsRefreshing = false;
        }

        public PizzeriaViewModel()
        {
            GoToPizzaDetailCommand = new Command(Go_toPizzaDetail);
            RefreshCommand = new Command(Do_refresh);
        }

        [NavigationParameter]
        public string Id
        {
            get => _restaurant_id;
            set { SetProperty<string>(ref _restaurant_id, value); } 
        }

        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

            Id = GetNavigationParameter<string>(Config.KEY_PIZZERIA_ID);

            Do_refresh(null);
        }

        public Pizza SelectedPizza
        {
            get => _selectedPizza;
            set { SetProperty<Pizza>(ref _selectedPizza, value); }
        }

        public Command GoToPizzaDetailCommand { get; }

        public bool IsRunning
        {
            get => _isRunning;
            set { SetProperty<bool>(ref _isRunning, value); }
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                SetProperty<bool>(ref _isRefreshing, value);
            }
        }
       
        public ObservableCollection<Pizza> Pizzas { get { return _pizzas; } }

        public Command RefreshCommand;
    }
}
