using PizzaIllico.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Storm.Mvvm;

using PizzaIllico.Models.Pizzeria;
using PizzaIllico.Models.Library;
using System.Collections;
using System.ComponentModel;

namespace PizzaIllico.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
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
                _isRunning = !_isRunning;
                 var args = new PropertyChangedEventArgs(nameof(IsRunning));
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
        public CollectionView CollectionView { get; }

        private void Go_toPizzeria(object obj)
        {
            if (_selectedPizerria != null)
            {
                // Pizzeria itemPizza = listView.SelectedItem as ItemPizzaria;

                // Navigation.PushAsync(new ListePizzaPage((itemPizza.id)));
            }
        }
        private void Do_refresh(object obj)
        {
            
            _publicService.RequestPizzeriaList((pizzerias) =>
            {
                _publicService.sortPizzerias((List<Pizzeria>)pizzerias.Data, _pizzerias);

            });
        }
    public HomeViewModel()
        {
            _pizzerias = new ObservableCollection<Pizzeria>();

            IsRefreshing = true;

            GoToPizzeriaDetailCommand = new Command(Go_toPizzeria);
            RefreshCommand = new Command(Do_refresh);

            RefreshCommand = new Command(Do_refresh);
            Do_refresh(null);

            IsRefreshing = false;

        }
    }
}
