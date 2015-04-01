using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using SearchFood.Model;
using SearchFood.Navigation;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.ViewModel
{
    public class CreateRestaurantViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ICommand GoBackButton { get; set; }
        public ICommand AjouterRestaurantButton { get; set; }

        private Services _service = new Services();

        List<Type_Cuisine> _typeCuisinelist = new List<Type_Cuisine>();
        List<Categorie> _categorieCuisineList = new List<Categorie>();

        #region TextBox

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

        private string _siteWeb;
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

        private string _mail;
        public string Mail
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

        private string _adresse;
        public string Adresse
        {
            get
            {
                return _adresse;
            }

            set
            {
                if (_adresse != value)
                {
                    _adresse = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _codePostal;
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

        private string _ville;
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

        private string _telephone;
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

        private string _latitude;
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

        private string _longitude;
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

        #region ComboBox

        private ObservableCollection<string> _typeDeCuisine = new ObservableCollection<string>();
        public ObservableCollection<string> TypeDeCuisine
        {
            get { return _typeDeCuisine; }
            set { _typeDeCuisine = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<string> _categorieCuisine = new ObservableCollection<string>();
        public ObservableCollection<string> CategorieCuisine
        {
            get { return _categorieCuisine; }
            set { _categorieCuisine = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<string> _dureeRepas = new ObservableCollection<string>();
        public ObservableCollection<string> DureeRepas
        {
            get
            {
                return _dureeRepas;
            }

            set
            {

                _dureeRepas = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _prix = new ObservableCollection<string>();
        public ObservableCollection<string> Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
                RaisePropertyChanged();
            }
        }

        private string _dureeRepasChoisie;
        public string DureeRepasChoisie
        {
            get
            {
                return _dureeRepasChoisie;
            }

            set
            {
                if (_dureeRepasChoisie != value)
                {
                    _dureeRepasChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _prixChoisie;
        public string PrixChoisie
        {
            get
            {
                return _prixChoisie;
            }

            set
            {
                if (_prixChoisie != value)
                {
                    _prixChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _typeCuisineChoisie;
        public string TypeCuisineChoisie
        {
            get
            {
                return _typeCuisineChoisie;
            }

            set
            {
                if (_typeCuisineChoisie != value)
                {
                    _typeCuisineChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _categorieChoisie;
        public string CategorieChoisie
        {
            get
            {
                return _categorieChoisie;
            }

            set
            {
                if (_categorieChoisie != value)
                {
                    _categorieChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Checkbox

        private bool _aEmporter;
        
        public bool AEmporter
        {
            get { return _aEmporter; }
            set { _aEmporter = value; }
        }

        #endregion

        public CreateRestaurantViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackButton = new RelayCommand(GoBack);
            AjouterRestaurantButton = new RelayCommand(AjouterRestaurant);
 
            InitComboBox();
        }

        public async void InitComboBox()
        {
            _typeCuisinelist = await _service._typesCuisines.GetTypesCuisines();
            _categorieCuisineList = await _service._categories.GetCategories();

            foreach (Type_Cuisine tc in _typeCuisinelist)
            {
                _typeDeCuisine.Add(tc.Type_Cuisine1);
            }

            foreach (Categorie cat in _categorieCuisineList)
            {
                _categorieCuisine.Add(cat.Nom_Categorie);
            }

            _prix.Add("Petit Budget");
            _prix.Add("Moyen Budget");
            _prix.Add("Gros Budget");

            _dureeRepas.Add("Rapide");
            _dureeRepas.Add("Moyen");
            _dureeRepas.Add("Long");

            CategorieCuisine = _categorieCuisine;
            TypeDeCuisine = _typeDeCuisine;
            Prix = _prix;
            DureeRepas = _dureeRepas;
        }

        public async void AjouterRestaurant()
        {
            if (Nom == null || SiteWeb == null || Mail == null || Adresse == null || CodePostal == null || Ville == null ||
                Telephone == null || Latitude == null || Longitude == null || DureeRepasChoisie == null ||
                PrixChoisie == null || CategorieChoisie == null || TypeCuisineChoisie == null)
            {
                MessageDialog msgDialog = new MessageDialog("Tous les champs doivent être renseignés", "Attention");
                await msgDialog.ShowAsync();
            }
            else
            {
                int idTypeCuisine = 1;
                int idCategorie = 1;
                bool aEmporter;
                int livraison;
                int dureeRepas = 1;
                int prix = 1;

                foreach (Type_Cuisine tc in _typeCuisinelist)
                {
                    if (tc.Type_Cuisine1.Equals(TypeCuisineChoisie))
                        idTypeCuisine = tc.Id_Type_Cuisine;
                }

                foreach (Categorie cat in _categorieCuisineList)
                {
                    if (cat.Nom_Categorie.Equals(CategorieChoisie))
                        idCategorie = cat.Id_Categorie;
                }

                aEmporter = AEmporter;
                if (aEmporter)
                {
                    livraison = 1;
                }
                else
                {
                    livraison = 0;
                }

                if (PrixChoisie.Equals("Petit Budget"))
                {
                    prix = 1;
                }
                else if (PrixChoisie.Equals("Moyen Budget"))
                {
                    prix = 2;
                }
                else
                {
                    prix = 3;
                }

                if (DureeRepasChoisie.Equals("Rapide"))
                {
                    dureeRepas = 1;
                }
                else if (DureeRepasChoisie.Equals("Moyen"))
                {
                    dureeRepas = 2;
                }
                else
                {
                    dureeRepas = 3;
                }

                Restaurant restaurant = new Restaurant { Nom = Nom, Site_Web = SiteWeb, Mail = Mail, Adresse = Adresse, Code_Postal = CodePostal, Ville = Ville, Telephone = Telephone, Latitude = Latitude, Longitude = Longitude, Duree_repas = dureeRepas, Prix = prix, Id_Categorie = idCategorie, Id_Type_Cuisine = idTypeCuisine, Livraison = livraison };

                _service._restaurants.AddRestaurants(restaurant);

                MessageDialog msgDialog2 = new MessageDialog("Le restaurant a été ajouter avec succès", "Félicitation");
                await msgDialog2.ShowAsync();
            }
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
