using System.Windows.Input; 
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Navigation;
using SearchFood.View;
using Windows.UI.Xaml; 

namespace SearchFood.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Visibility _connectedHeader;
        private Visibility _deconnectedHeader;  
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
            SearchCommand = new RelayCommand(Search);
            AccountCommande = new RelayCommand(Account);
            RestauCommand = new RelayCommand(Restau);
            //if (((App)(Application.Current)).UserConnected != null)
            
            
        }

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand RestauCommand { get; set; }

        public ICommand CreateAccountCommand { get; set; }

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

        public void Restau()
        {
            _navigationService.Navigate(typeof(Restau));
        }

        
        public void Logout()
        {
            ConnectedHeader = Visibility.Collapsed;
            DeconnectedHeader = Visibility.Visible; 
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
    }
}