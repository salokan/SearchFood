using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Common;
using SearchFood.Navigation;
using Windows.UI.Popups;
using SearchFood.SearchFoodServiceReference;
using SearchFood.View;
using SearchFood.Model;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using RelayCommand = SearchFood.Common.RelayCommand;

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
        private Services _userService;


        public LogViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _userService = new Services();
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
        public async void Login()
        {
            if (_pseudoLogin != null && !_pseudoLogin.Equals("") && _passwordLogin != null && !_passwordLogin.Equals(""))
            {
                var userconnected = await _userService._utilisateurs.AuthentificationUtilisateur(_pseudoLogin, _passwordLogin);

                if (userconnected != null)
                {
                    ((App)(Application.Current)).UserConnected = userconnected;
                    _navigationService.Navigate(typeof(MainPage));
                }
                else
                {
                    MessageDialog msgDialog = new MessageDialog("Echec de l'authentification", "Echec");
                    await msgDialog.ShowAsync();
                }
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Veuillez entrer un Login et un Mot de Passe", "Echec");
                await msgDialog.ShowAsync();
            }
        }

        public async void Inscription()
        {
            if (_emailInscription != null && !_emailInscription.Equals("") && _nomInscription != null && !_nomInscription.Equals("") && _prenomInscription != null && !_prenomInscription.Equals("") && _passwordInscription != null && !_passwordInscription.Equals("") && _pseudoInscription != null && !_pseudoInscription.Equals(""))
            {
                if (IsValidEmail(_emailInscription))
                {

                    bool pseudoexist = await _userService._utilisateurs.ExistePseudo(_pseudoInscription);
                    if (!pseudoexist)
                    {
                        bool mailexist = await _userService._utilisateurs.ExisteMail(_emailInscription);
                        if (!mailexist)
                        {
                            Utilisateur user = new Utilisateur();
                            user.Mail = _emailInscription;
                            user.Nom = _nomInscription;
                            user.Prenom = _prenomInscription;
                            user.Password = _passwordInscription;
                            user.Pseudonyme = _pseudoInscription;
                            String inscription = await _userService._utilisateurs.AddUtilisateurs(user);
                            if (inscription.Equals("success"))
                            {
                                MessageDialog msgDialog = new MessageDialog("Inscription réussie", "Bravo");
                                await msgDialog.ShowAsync();
                            }
                            else
                            {
                                MessageDialog msgDialog = new MessageDialog("Echec de l'incription, veuillez recommencer", "Echec");
                                await msgDialog.ShowAsync();
                            }
                        }
                        else
                        {
                            MessageDialog msgDialog = new MessageDialog("Cet email est déjà utilisé", "Echec");
                            await msgDialog.ShowAsync();
                        }
                    }
                    else
                    {
                        MessageDialog msgDialog = new MessageDialog("Ce login est déjà utilisé", "Echec");
                        await msgDialog.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog msgDialog = new MessageDialog("Veuillez entrer un email correct", "Echec");
                    await msgDialog.ShowAsync();
                }
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Veuillez remplir le formulaire", "Echec");
                await msgDialog.ShowAsync();
            }
        }

        public void GooglePlus()
        {

        }

        public void Facebook()
        { 

        }
        public bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))
                return false;
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        #endregion
    }
}
