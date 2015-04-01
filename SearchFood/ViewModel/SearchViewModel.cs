using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Model;
using SearchFood.Navigation;
using SearchFood.SearchFoodServiceReference;
using SearchFood.View;

namespace SearchFood.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private List<Restaurant> restaurantsListe = new List<Restaurant>();
        private int idResultat = 0;
        private int idRestaurant = 0;

        private Services _service = new Services();

        #region Boutons

        public ICommand RechercherBouton { get; set; }

        public ICommand ChoisirBouton { get; set; }

        public ICommand SuivantBouton { get; set; }

        public ICommand GoBackButton { get; set; }

        #endregion

        #region Slider

        private string _distance;
        public string Distance
        {
            get
            {
                return _distance;
            }

            set
            {
                if (_distance != value)
                {
                    _distance = value + " Km";
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Radio Boutons

        private bool _petitBudget;

        public bool PetitBudget
        {
            get { return _petitBudget; } 
            set{ _petitBudget = value; }
        }

        private bool _moyenBudget;

        public bool MoyenBudget
        {
            get { return _moyenBudget; }
            set { _moyenBudget = value; }
        }

        private bool _grosBudget;

        public bool GrosBudget
        {
            get { return _grosBudget; }
            set { _grosBudget = value; }
        }

        private bool _peuImporteBudget;

        public bool PeuImporteBudget
        {
            get { return _peuImporteBudget; }
            set { _peuImporteBudget = value; }
        }

        private bool _courtDelai;

        public bool CourtDelai
        {
            get { return _courtDelai; }
            set { _courtDelai = value; }
        }

        private bool _moyenDelai;

        public bool MoyenDelai
        {
            get { return _moyenDelai; }
            set { _moyenDelai = value; }
        }

        private bool _longDelai;

        public bool LongDelai
        {
            get { return _longDelai; }
            set { _longDelai = value; }
        }

        private bool _peuImporteDelai;

        public bool PeuImporteDelai
        {
            get { return _peuImporteDelai; }
            set { _peuImporteDelai = value; }
        }

        #endregion

        #region Combobox

        public ObservableCollection<string> TypeDeCuisine
        {
            get { return _typeDeCuisine1; }
            set { _typeDeCuisine1 = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<string> CategorieCuisine
        {
            get { return _categorieCuisine; }
            set { _categorieCuisine = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<string> _typeDeCuisine = new ObservableCollection<string>();


        public ObservableCollection<int> MinNotation
        {
            get { return _minNotation1; }
            set { _minNotation1 = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<int> _minNotation = new ObservableCollection<int>();

        public ObservableCollection<int> MaxNotation
        {
            get { return _maxNotation1; }
            set { _maxNotation1 = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<int> _maxNotation = new ObservableCollection<int>();

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

        private string _categorieCuisineChoisie;
        public string CategorieCuisineChoisie
        {
            get
            {
                return _categorieCuisineChoisie;
            }

            set
            {
                if (_categorieCuisineChoisie != value)
                {
                    _categorieCuisineChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _minNotationChoisie;
        public int MinNotationChoisie
        {
            get
            {
                return _minNotationChoisie;     
            }

            set
            {
                if (_minNotationChoisie != value)
                {
                    _minNotationChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _maxNotationChoisie;
        public int MaxNotationChoisie
        {
            get
            {
                return _maxNotationChoisie;
            }

            set
            {
                if (_maxNotationChoisie != value)
                {
                    _maxNotationChoisie = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Checkbox

        private bool _aEmporter;
        private ObservableCollection<string> _typeDeCuisine1;
        private ObservableCollection<string> _categorieCuisine = new ObservableCollection<string>();
        private ObservableCollection<int> _minNotation1;
        private ObservableCollection<int> _maxNotation1;
        List<Type_Cuisine> typeCuisinelist = new List<Type_Cuisine>();
        List<Categorie> categorieCuisineList = new List<Categorie>();
        List<Note> noteList = new List<Note>();

        public bool AEmporter
        {
            get { return _aEmporter; }
            set { _aEmporter = value; }
        }

        #endregion

        #region Résultat

        private string _nomResultat;
        public string NomResultat
        {
            get
            {
                return _nomResultat;
            }

            set
            {
                if (_nomResultat != value)
                {
                    _nomResultat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _dureeResultat;
        public string DureeResultat
        {
            get
            {
                return _dureeResultat;
            }

            set
            {
                if (_dureeResultat != value)
                {
                    _dureeResultat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _prixResultat;
        public string PrixResultat
        {
            get
            {
                return _prixResultat;
            }

            set
            {
                if (_prixResultat != value)
                {
                    _prixResultat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _categorieResultat;
        public string CategorieResultat
        {
            get
            {
                return _categorieResultat;
            }

            set
            {
                if (_categorieResultat != value)
                {
                    _categorieResultat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _typeCuisineResultat;
        public string TypeCuisineResultat
        {
            get
            {
                return _typeCuisineResultat;
            }

            set
            {
                if (_typeCuisineResultat != value)
                {
                    _typeCuisineResultat = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        #endregion


        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RechercherBouton = new RelayCommand(Rechercher);
            ChoisirBouton = new RelayCommand(Choisir);
            SuivantBouton = new RelayCommand(Suivant);
            GoBackButton = new RelayCommand(GoBack); 
            
            InitComponents();
        }

        private async void InitComponents()
        {
            typeCuisinelist = await _service._typesCuisines.GetTypesCuisines();
            categorieCuisineList = await _service._categories.GetCategories();

            foreach (Type_Cuisine tc in typeCuisinelist)
            {
                _typeDeCuisine.Add(tc.Type_Cuisine1);
            }

            foreach (Categorie cat in categorieCuisineList)
            {
                _categorieCuisine.Add(cat.Nom_Categorie);
            }

            for (int i = 0; i < 5; i++)
            {
                _minNotation.Add(i + 1);
                _maxNotation.Add(i + 1);
            }

            CategorieCuisine = _categorieCuisine;
            TypeDeCuisine = _typeDeCuisine;
            MinNotation = _minNotation;
            MaxNotation = _maxNotation;
        }

        private async void Rechercher()
        {
            restaurantsListe.Clear();
            //trouver un moyen de vider la gridview
            string prix;
            string distance;
            string delai;
            bool aEmporter;
            int livraison;
            int minNote;
            int maxNote;
            int idTypeDeCuisine = 0;
            int idCategorieCuisine = 0;

            if (_petitBudget)
                prix = "1";
            else if (_moyenBudget)
                prix = "2";
            else if (_grosBudget)
                prix = "3";
            else
                prix = "";

            distance = _distance;

            if (_courtDelai)
                delai = "1";
            else if (_moyenDelai)
                delai = "2";
            else if (_longDelai)
                delai = "3";
            else
                delai = "";

            foreach (Type_Cuisine tc in typeCuisinelist)
            {
                if(tc.Type_Cuisine1.Equals(_typeCuisineChoisie))
                {
                    idTypeDeCuisine = tc.Id_Type_Cuisine;
                }
            }

            foreach (Categorie cat in categorieCuisineList)
            {
                if (cat.Nom_Categorie.Equals(_categorieCuisineChoisie))
                {
                    idCategorieCuisine = cat.Id_Categorie;
                }
            }

            aEmporter = _aEmporter;
            if(aEmporter)
            {
                livraison = 1;
            } else {
                livraison = 0;
            }
            minNote = _minNotationChoisie;
            maxNote = _maxNotationChoisie;

            restaurantsListe = await _service._restaurants.GetRestaurants();
            //restaurantsListe = restaurantsListe.FindAll(s =>
            //    (s.Prix.ToString().Equals(prix) || prix.Equals("") || prix == null) &&
            //    (s.Duree_repas.ToString().Equals(delai) || delai.Equals("") || delai == null)  &&
            //    (s.Id_Type_Cuisine == idTypeDeCuisine) &&
            //    (s.Id_Categorie == idCategorieCuisine) &&
            //    (s.Livraison == livraison)
            //    );



            if (restaurantsListe.Count != 0)
            {
                idResultat = 0;
                idRestaurant = restaurantsListe[idResultat].Id_Restaurant;
                NomResultat = "Nom : " + restaurantsListe[idResultat].Nom;
                Categorie categorie = await _service._categories.GetCategorie(restaurantsListe[idResultat].Id_Categorie);
                CategorieResultat = "Catégorie : " + categorie.Nom_Categorie;
                if (restaurantsListe[idResultat].Prix == 1)
                {
                    PrixResultat = "Prix : Petit Budget";
                }
                else if (restaurantsListe[idResultat].Prix == 2)
                {
                    PrixResultat = "Prix : Budget Moyen";
                }
                else
                {
                    PrixResultat = "Prix : Gros Budget";
                }
                if (restaurantsListe[idResultat].Duree_repas == 1)
                {
                    DureeResultat = "Durée : Rapide";
                }
                else if (restaurantsListe[idResultat].Duree_repas == 2)
                {
                    DureeResultat = "Durée : Moyen";
                }
                else
                {
                    DureeResultat = "Durée : Long";
                }
                Type_Cuisine typeCuisine = await _service._typesCuisines.GetTypeCuisine(restaurantsListe[idResultat].Id_Type_Cuisine);
                TypeCuisineResultat = "Type de cuisine : " + typeCuisine.Type_Cuisine1;
            }
            else
            {
                MessageDialog msgDialog2 = new MessageDialog("Aucun restaurant ne correspond à votre recherche", "Attention");
                await msgDialog2.ShowAsync();
            }
        }

        private async void Choisir()
        {
            if (idRestaurant <= 0)
            {
                MessageDialog msgDialog = new MessageDialog("Vous n'avez pas choisi de restaurant", "Attention");
                await msgDialog.ShowAsync();
            }
            else
                _navigationService.Navigate(typeof(Restau), idRestaurant);
        }

        private async void Suivant()
        {
            if (restaurantsListe.Count != 0)
            {
                //faire si liste > 0
                if (idResultat == restaurantsListe.Count - 1)
                    idResultat = 0;
                else
                    idResultat++;

                idRestaurant = restaurantsListe[idResultat].Id_Restaurant;
                NomResultat = "Nom : " + restaurantsListe[idResultat].Nom;
                Categorie categorie = await _service._categories.GetCategorie(restaurantsListe[idResultat].Id_Categorie);
                CategorieResultat = "Catégorie : " + categorie.Nom_Categorie;
                if (restaurantsListe[idResultat].Prix == 1)
                {
                    PrixResultat = "Prix : Petit Budget";
                }
                else if (restaurantsListe[idResultat].Prix == 2)
                {
                    PrixResultat = "Prix : Budget Moyen";
                }
                else
                {
                    PrixResultat = "Prix : Gros Budget";
                }
                if (restaurantsListe[idResultat].Duree_repas == 1)
                {
                    DureeResultat = "Durée : Rapide";
                }
                else if (restaurantsListe[idResultat].Duree_repas == 2)
                {
                    DureeResultat = "Durée : Moyen";
                }
                else
                {
                    DureeResultat = "Durée : Long";
                }
                Type_Cuisine typeCuisine = await _service._typesCuisines.GetTypeCuisine(restaurantsListe[idResultat].Id_Type_Cuisine);
                TypeCuisineResultat = "Type de cuisine : " + typeCuisine.Type_Cuisine1;
            }
        }

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
