using System;
using System.Windows.Input; 
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Navigation;
using SearchFood.View;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const String Hidden = "Collapsed";
        private const String Visible = "Visible";
        private String _visibility;
        private String _inverseVisibility;
        private String _loginConnected;
        private Boolean _popupOpen;
        private Boolean _log; 
        private readonly INavigationService _navigationService;
        private Utilisateur _userConnected;

        public MainViewModel(INavigationService navigation)
        {
            _userConnected = ((App)(App.Current)).UserConnected;
            _log = false;
            _popupOpen = false;
            _visibility = Hidden;
            _inverseVisibility = Visible;
            _navigationService = navigation;
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
            SearchCommand = new RelayCommand(Search);
            RestauCommand = new RelayCommand(Restau);
            PopupOpenCommande = new RelayCommand(ClickProfil);
            CreateAccountCommand = new RelayCommand(CreateAccount);
            if (_userConnected != null)
            {
                _loginConnected = _userConnected.Pseudonyme;
            }
        }

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand RestauCommand { get; set; }

        public ICommand CreateAccountCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand PopupOpenCommande { get; set; }
        #endregion

        #region Command Methode
        public void Login()
        {
            Visibility = Visibility == Visible ? Hidden : Visible;
            InverseVisibility = _visibility == Visible ? Hidden : Visible;
        }
        public void Search()
        {
            _navigationService.Navigate(typeof(Search));
        }

        public void Restau()
        {
            _navigationService.Navigate(typeof(Restau));
        }

        public void ClickProfil()
        {
            PopupOpen = !_popupOpen;
        }

        public void CreateAccount()
        {
            _navigationService.Navigate(typeof(Create_Connexion));
        }

        public void Logout()
        {
            Visibility = Hidden;
            InverseVisibility = Visible;
            Log = false;
        }
        #endregion

        #region Getter / Setter MVVM
        public Boolean PopupOpen
        {
            get { return _popupOpen; }
            set { _popupOpen = value; RaisePropertyChanged(); }
        }

        public Boolean Log
        {
            get { return _log; }
            set { _log = value; RaisePropertyChanged(); }
        }

        public String Visibility
        {
            get { return _visibility; }
            set { _visibility = value; RaisePropertyChanged(); }
        }

        public String InverseVisibility
        {
            get {
                return _inverseVisibility;
            }
            set { _inverseVisibility = value; RaisePropertyChanged(); }
        }
        public String LoginConnected
        {
            get { return _loginConnected; }
            set { _loginConnected = value; RaisePropertyChanged(); }
        }
        #endregion
    }
}