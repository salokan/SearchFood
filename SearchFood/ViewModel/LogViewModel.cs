using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Navigation;

namespace SearchFood.ViewModel
{
    public class LogViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private String _nomInscription;
        private String _prenomInscription;
        private String _pseudoInscription;
        private String _emailInscription;
        private String _passwordInscription;
        private String _pseudoLogin;
        private String _passwordLogin;

        public LogViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Inscription);
            GooglePlusCommand = new RelayCommand(GooglePlus);
            FacebookCommand = new RelayCommand(Facebook);
        }

        #region Getter / Setter MVVM
        public String NomInscription
        {
            get { return _nomInscription; }
            set { _nomInscription = value; RaisePropertyChanged(); }
        }

        public String PrenomInscription
        {
            get { return _prenomInscription; }
            set { _prenomInscription = value; RaisePropertyChanged(); }
        }

        public String PseudoInscription
        {
            get { return _pseudoInscription; }
            set { _pseudoInscription = value; RaisePropertyChanged(); }
        }

        public String EmailInscription
        {
            get
            {
                return _emailInscription;
            }
            set { _emailInscription = value; RaisePropertyChanged(); }
        }

        public String PasswordInscription
        {
            get
            {
                return _passwordInscription;
            }
            set { _passwordInscription = value; RaisePropertyChanged(); }
        }

        public String PseudoLogin
        {
            get
            {
                return _pseudoLogin;
            }
            set { _pseudoLogin = value; RaisePropertyChanged(); }
        }

        public String PasswordLogin
        {
            get
            {
                return _passwordLogin;
            }
            set { _passwordLogin = value; RaisePropertyChanged(); }
        }
        #endregion

        # region Getter / Setter Button
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand GooglePlusCommand { get; set; }

        public ICommand FacebookCommand { get; set; }
        #endregion

        #region Command Methode
        public void Login()
        {

        }

        public void Inscription()
        {

        }

        public void GooglePlus()
        {

        }

        public void Facebook()
        { 

        }
        #endregion

    }
}
