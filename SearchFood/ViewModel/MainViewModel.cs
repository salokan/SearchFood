using System;
using System.Windows.Input; 
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Navigation;
using SearchFood.View;
using SearchFood.SearchFoodServiceReference;
using Windows.UI.Xaml;
using System.ComponentModel;

namespace SearchFood.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Visibility _connectedHeader;
        private Visibility _deconnectedHeader;
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
            _navigationService = navigation;
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
            SearchCommand = new RelayCommand(Search);
            PopupOpenCommande = new RelayCommand(ClickProfil);
            if (_userConnected != null)
            {
                ConnectedHeader = Visibility.Visible;
                DeconnectedHeader = Visibility.Collapsed;
                _loginConnected = _userConnected.Pseudonyme;
            }
            else
            {
                ConnectedHeader = Visibility.Collapsed;
                DeconnectedHeader = Visibility.Visible;

            }
        }

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand PopupOpenCommande { get; set; }
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

        public void ClickProfil()
        {
            PopupOpen = !_popupOpen;
        }

        public void Logout()
        {
            ConnectedHeader = Visibility.Collapsed;
            DeconnectedHeader = Visibility.Visible;
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
        public String LoginConnected
        {
            get { return _loginConnected; }
            set { _loginConnected = value; RaisePropertyChanged(); }
        }
        #endregion
    }
}