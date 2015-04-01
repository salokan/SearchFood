using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Navigation; 
using SearchFood.SearchFoodServiceReference;
using SearchFood.Model;  

namespace SearchFood.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private Utilisateur _utilisateur;
        private List<Historique> _historiques;
        private Restaurant restaurant;
        private List<Restaurant> _historiqueRestaurant;
        private INavigationService _navigationService;
        private Services _service;
        
        public ICommand GoBackButton { get; set; }

        public AccountViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _service = new Services();
            Historiques = new List<Historique>();
            HistoriqueRestaurant = new List<Historique>();
            GoBackButton = new RelayCommand(GoBack);

            InitHistorique();
        }

        private async void InitHistorique()
        {
            _historiques = await _service._historique.GetHistoriqueByUser(((App)(Application.Current)).UserConnected.Id_Utilisateur);

            foreach (Historique histo in _historiques)
            {
                //restaurant = await _service._restaurants.GetRestaurantsById(histo.Id_Restaurant);
                //_historiqueRestaurant.Add(restaurant);
            }
        }

        #region Getter / Setter MVVM 
        public Utilisateur Utilisateur
        {
            get { return _utilisateur; }
            set { _utilisateur = value; RaisePropertyChanged(); }
        }
        public List<Historique> Historiques
        {
            get { return _historiques; }
            set { _historiques = value; RaisePropertyChanged(); }
        }
        public List<Restaurant> HistoriqueRestaurant
        {
            get { return _historiqueRestaurant; }
            set { _historiques = value; RaisePropertyChanged(); }
        }

        private string _nom;
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _duree;
        public string Duree
        {
            get
            {
                return _duree;
            }

            set
            {
                if (_duree != value)
                {
                    _duree = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date != value)
                {
                    _date = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _prix;
        public string Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                if (_prix != value)
                {
                    _prix = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _categorie;
        public string Categorie
        {
            get
            {
                return _categorie;
            }

            set
            {
                if (_categorie != value)
                {
                    _categorie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _typeCuisine;
        public string TypeCuisine
        {
            get
            {
                return _typeCuisine;
            }

            set
            {
                if (_typeCuisine != value)
                {
                    _typeCuisine = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _commentaire;
        public int Commentaire
        {
            get
            {
                return _commentaire;
            }

            set
            {
                if (_commentaire != value)
                {
                    _commentaire = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
