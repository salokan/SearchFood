using System;
using System.Windows.Input; 
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Navigation;
using SearchFood.View;

namespace SearchFood.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const String Hidden = "Collapsed";
        private const String Visible = "Visible";
        private String _visibility;
        private String _inverseVisibility;
        private Boolean _popupOpen;
        private Boolean _log; 
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigation)
        {
            _log = false;
            _popupOpen = false;
            _visibility = Visible;
            _inverseVisibility = Hidden;
            _navigationService = navigation;
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
            SearchCommand = new RelayCommand(Search);
            PopupOpenCommande = new RelayCommand(ClickProfil);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand SearchCommand { get; set; }

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
        #endregion
    }
}