using System.Windows.Input; 
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Navigation;
using SearchFood.View;
using Windows.UI.Xaml; 
using SearchFood.SearchFoodServiceReference;
using System.Collections.Generic;
using System;
using SearchFood.Model; 

namespace SearchFood.ViewModel
{
    public class MainViewModel : ViewModelBase, IViewModel
    {
        private Visibility _connectedHeader;
        private Visibility _deconnectedHeader;  
        private readonly INavigationService _navigationService;
        private List<Restaurant> restaurantsListe = new List<Restaurant>();
        private Services _service;

        public MainViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _service = new Services();
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
            SearchCommand = new RelayCommand(Search);
            AccountCommande = new RelayCommand(Account);
            RestauCommand = new RelayCommand(Restau);
            CreateRestaurantCommand = new RelayCommand(MonRestaurant);

            ConnectedHeader = Visibility.Collapsed;
            DeconnectedHeader = Visibility.Visible; 
        }

        public void InitMain()
        {
            if (((App)(Application.Current)).UserConnected != null)
            {
                ConnectedHeader = Visibility.Visible;
                DeconnectedHeader = Visibility.Collapsed;
            }
        }

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand CreateRestaurantCommand { get; set; }

        public ICommand CreateAccountCommand { get; set; }
        public ICommand RestauCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand AccountCommande { get; set; }
        #endregion

        #region Command Methode
        public void Login()
        {
            _navigationService.Navigate(typeof(Create_Connexion));
        }
        public void Search()
        {
            _navigationService.Navigate(typeof(Search));
        }

        public void MonRestaurant()
        {
            _navigationService.Navigate(typeof(CreateRestaurant));
        }

        public async void Restau()
        {
            Random rnd = new Random();
            restaurantsListe = await _service._restaurants.GetRestaurants();
            int r = rnd.Next(restaurantsListe.Count);
            _navigationService.Navigate(typeof(Restau), restaurantsListe[r].Id_Restaurant);
        }
        
        public void Logout()
        {
            ConnectedHeader = Visibility.Collapsed;
            DeconnectedHeader = Visibility.Visible;

            ((App) (Application.Current)).UserConnected = null;
        }
        public void Account()
        {
            _navigationService.Navigate(typeof(Account));
        }
        #endregion

        #region Getter / Setter MVVM
        public Visibility ConnectedHeader
        {
            get { return _connectedHeader; }
            set { _connectedHeader = value; RaisePropertyChanged(); }
        }

        public Visibility DeconnectedHeader
        {
            get {
                return _deconnectedHeader;
        }
            set { _deconnectedHeader = value; RaisePropertyChanged(); }
        }
        #endregion

        //Récupère le paramètre contenant la définition à modifier
        public void GetParameter(object parameter)
        {

        }

        //Permet de réinitialiser la liste à chaque fois que l'on navigue sur cette page
        public void OnNavigatedTo()
        {
            InitMain();
        }
    }
}