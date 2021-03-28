using PizzaIllico.Models.Library;
using PizzaIllico.Models.Pizzeria;
using PizzaIllico.Resources.Config;
using PizzaIllico.Services;
using PizzaIllico.Views;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PizzaIllico.ViewModels
{
    class PizzeriaViewModel : PageLayoutViewModel
    {
        private string _restaurant_id;
        private Pizzeria _currentPizzeria;
        private Pizza _selectedPizza;

        private IPizzeriaService _publicService = DependencyService.Get<IPizzeriaService>();

        private ObservableCollection<Pizza> _pizzas = new ObservableCollection<Pizza>();

        public PizzeriaViewModel()
        {
            SelectedPizzasChangedCommand = new Command(OnPizzaSelectionChanged);

            FooterButtonHomeCommand = new Command(async () => await NavigationService.PushAsync<HomePage>(GetNavigationParameters()));
            FooterButtonAccountCommand = new Command(async () => await NavigationService.PushAsync<AccountPage>(GetNavigationParameters()));
            FooterButtonMapCommand = new Command(async () => await NavigationService.PushAsync<MapPage>(GetNavigationParameters()));
            FooterButtonCartCommand = new Command(async () => await NavigationService.PushAsync<CartPage>(GetNavigationParameters()));
            
        }
        public override void Initialize(Dictionary<string, object> navigationParameters)
        {
            base.Initialize(navigationParameters);

            _currentPizzeria = GetNavigationParameter<Pizzeria>(Config.KEY_PIZZERIA);
            Id = _currentPizzeria.Id;
            Do_refresh(null);

        }

        // ----------------------------------------------------------------------------------------------------------------------------
        private void OnPizzaSelectionChanged(object sender)
        {
            if(_selectedPizza != null)
            {
                CurrentCart.Pizzas.Remove(_selectedPizza);
                if (_selectedPizza.ToggleSelected())
                {
                    CurrentCart.Pizzas.Add(_selectedPizza);
                }
            } 
        }

        private bool is_selected = false;
        public bool IsSelected
        {
            get => is_selected;
            set { 
                SetProperty(ref is_selected, value); 
            }
        }
        private void Do_refresh(object obj)
        {
            _publicService.RequestRestaurantPizzaList((pizzas) =>
            {
                _publicService.sortPizzas(_currentPizzeria, (List<Pizza>)pizzas, _pizzas);
            }, Id);
        }
        public string Id
        {
            get => _restaurant_id;
            set { SetProperty<string>(ref _restaurant_id, value); } 
        }
        
        public Pizzeria CurrentPizzeria
        {
            get => _currentPizzeria;
            set => _currentPizzeria = value;
        }
        public Pizza SelectedPizza
        {
            get => _selectedPizza;
            set { SetProperty<Pizza>(ref _selectedPizza, value); }
        }
        
        public ObservableCollection<Pizza> Pizzas { get { return _pizzas; } }

        public Command SelectedPizzasChangedCommand
        {
            get; set;
        }
        
    }
}
