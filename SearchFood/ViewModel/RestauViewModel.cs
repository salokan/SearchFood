using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using SearchFood.Common;
using SearchFood.Model;
using SearchFood.Navigation;
using SearchFood.SearchFoodServiceReference;
using System.Threading.Tasks;
using Bing.Maps;

namespace SearchFood.ViewModel
{
    public class RestauViewModel : ViewModelBase, IViewModel
    {
        private List<Commentaire> _commentsListe = new List<Commentaire>();
        private INavigationService _navigationService;
        private Restaurant _restaurant = new Restaurant();
        private int _idrestau;
        private string _nomRestaurant;
        private int _dureeRepas;
        private String _adresseRestaurant;
        private string _codePostal;
        private String _ville;
        private int _prixRestaurant;
        private string _siteWeb;
        private string _telephone;
        private string _mail;
        private string _latitude;
        private string _longitude;

        private int _idCommentaireExiste;
        
        private string _newCommentaire;

        private Services _service;
        private string _textBoutonCommentaire;

        public ICommand AjouterCommentaireButton { get; set; }
        public ICommand GoBackButton { get; set; }
        

        #region Champs Restaurant
        public string NomRestaurant 
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

        public int DureeRepas 
        {
            get
            {
                return _dureeRepas;
            }

            set
            {
                if (_dureeRepas != value)
                {
                    _dureeRepas = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string AdresseRestaurant 
        {
            get
            {
                return _adresseRestaurant;
            }

            set
            {
                if (_adresseRestaurant != value)
                {
                    _adresseRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string CodePostal 
        {
            get
            {
                return _codePostal;
            }

            set
            {
                if (_codePostal != value)
                {
                    _codePostal = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Ville 
        {
            get
            {
                return _ville;
            }

            set
            {
                if (_ville != value)
                {
                    _ville = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int PrixRestaurant 
        {
            get
            {
                return _prixRestaurant;
            }

            set
            {
                if (_prixRestaurant != value)
                {
                    _prixRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string SiteWeb 
        {
            get
            {
                return _siteWeb;
            }

            set
            {
                if (_siteWeb != value)
                {
                    _siteWeb = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Telephone 
        {
            get
            {
                return _telephone;
            }

            set
            {
                if (_telephone != value)
                {
                    _telephone = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String Mail 
        {
            get
            {
                return _mail;
            }

            set
            {
                if (_mail != value)
                {
                    _mail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Latitude 
        {
            get
            {
                return _latitude;
            }

            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Longitude 
        {
            get
            {
                return _longitude;
            }

            set
            {
                if (_longitude != value)
                {
                    _longitude = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Champs Commentaire

        public ObservableCollection<CommentairesModel> Commentaireslist
        {
            get { return _commentairesList; }

            set
            {
                _commentairesList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<CommentairesModel> _commentairesList = new ObservableCollection<CommentairesModel>();

        public string NewCommentaire
        {
            get
            {
                return _newCommentaire;
            }

            set
            {
                if (_newCommentaire != value)
                {
                    _newCommentaire = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string TextBoutonCommentaire
        {
            get
            {
                return _textBoutonCommentaire;
            }

            set
            {
                if (_textBoutonCommentaire != value)
                {
                    _textBoutonCommentaire = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        public RestauViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _service = new Services();
            AjouterCommentaireButton = new RelayCommand(AjouterCommentaire);
            GoBackButton = new RelayCommand(GoBack);  
        }

        public async void InitRestau()
        {
            _restaurant = await _service._restaurants.GetRestaurants(_idrestau);
            NomRestaurant = _restaurant.Nom;
            if (_restaurant.Duree_repas != null) DureeRepas = (int) _restaurant.Duree_repas;
            AdresseRestaurant = AdresseRestaurant = _restaurant.Adresse;
            CodePostal = _restaurant.Code_Postal;
            Ville = _restaurant.Ville;
            if (_restaurant.Prix != null) PrixRestaurant = (int) _restaurant.Prix;
            SiteWeb = _restaurant.Site_Web;
            Telephone = _restaurant.Telephone;
            Mail = _restaurant.Mail;
            Latitude = _restaurant.Latitude;
            Longitude = _restaurant.Longitude;

            //Si l'utilisateur est authentifié, on récupère son commentaire si il en a un et on l'affiche
            if (((App) (Application.Current)).UserConnected != null)
            {
                Commentaire commentaire = await _service._commentaires.GetCommentairesByUserAndRestaurant(((App) (Application.Current)).UserConnected.Id_Utilisateur,_idrestau);

                if (commentaire.Id_Utilisateur == ((App) (Application.Current)).UserConnected.Id_Utilisateur)
                {
                    NewCommentaire = commentaire.Commentaire1;
                    TextBoutonCommentaire = "Modifier Commentaire";
                    _idCommentaireExiste = commentaire.Id_Commentaire;
                }
                else
                {
                    NewCommentaire = "Ajouter un commentaire";
                    TextBoutonCommentaire = "Ajouter Commentaire";
                    _idCommentaireExiste = 0;
                }
            }
            else
            {
                NewCommentaire = "Connectez vous pour poster un commentaire";
                TextBoutonCommentaire = "Ajouter Commentaire";
            }
        }

        public async void InitCommentaireList()
        {
            _commentairesList = new ObservableCollection<CommentairesModel>();
            _commentsListe = await _service._commentaires.GetCommentairesByRestaurant(_idrestau);
           
            Utilisateur utilisateur;

            foreach (Commentaire c in _commentsListe)
            {
                CommentairesModel commentairesModel = new CommentairesModel();
                commentairesModel.Commentaire = c.Commentaire1;
                utilisateur = await _service._utilisateurs.GetUtilisateur(c.Id_Utilisateur);
                commentairesModel.Utilisateur = utilisateur.Pseudonyme;
                _commentairesList.Add(commentairesModel);
        }

            Commentaireslist = _commentairesList;
        }

        public async void AjouterCommentaire()
        {
            if(((App)(Application.Current)).UserConnected != null)
            {
                if (_idCommentaireExiste != 0)
        {
                    Commentaire commentaire = new Commentaire {Id_Commentaire = _idCommentaireExiste, Commentaire1 = NewCommentaire, Id_Restaurant = _idrestau, Id_Utilisateur = ((App)(Application.Current)).UserConnected.Id_Utilisateur };

                    _service._commentaires.UpdateCommentaires(commentaire);

                    MessageDialog msgDialog = new MessageDialog("Commentaire modifié avec succès", "Félicitation");
                    await msgDialog.ShowAsync();
                }
                else
                {
                    Commentaire commentaire = new Commentaire { Commentaire1 = NewCommentaire, Id_Restaurant = _idrestau, Id_Utilisateur = ((App)(Application.Current)).UserConnected.Id_Utilisateur };

                    _service._commentaires.AddCommentaires(commentaire);

                    MessageDialog msgDialog = new MessageDialog("Commentaire ajouté avec succès", "Félicitation");
                    await msgDialog.ShowAsync();
                }
                InitRestau();
                InitCommentaireList();
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Vous n'êtes pas connecté", "Attention");
                await msgDialog.ShowAsync();
            }   
        }
                
        public void GoBack()
        {
            _navigationService.GoBack();
        }
        
        //Récupère le paramètre contenant la définition à modifier
        public void GetParameter(object parameter)
        {
            _idrestau = (int) parameter;
            InitRestau();
            InitCommentaireList();
        }

        //Permet de réinitialiser la liste à chaque fois que l'on navigue sur cette page
        public void OnNavigatedTo()
        {

        }
    }
}
