using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Model;
using SearchFood.Navigation;
using SearchFood.SearchFoodServiceReference;
using SearchFood.View;
using SearchFood.Webservices;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace SearchFood.ViewModel
{
    public class RestauViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private String _adresseRestaurant;
        private String _prixRestaurant;
        private Services _restauServices;
        private string _nomRestaurant;
        public string NomRestaurant //Mot à ajouter
        {
            get
            {
                return _nomRestaurant;
            }

            set
            {
                if (_nomRestaurant != value)
                {
                    _nomRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public RestauViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            GetRestau = new RelayCommand(Restau);

        }

        public ICommand GetRestau { get; set; }

        public async void Restau()
        {
            Restaurant caca = new Restaurant();
            caca = await _restauServices._restaurants.GetRestaurants(1);
            string test = caca.Nom;
        }
    }
}
