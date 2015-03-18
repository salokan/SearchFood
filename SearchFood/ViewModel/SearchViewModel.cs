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

namespace SearchFood.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand RechercherBouton { get; set; }

        private Services _service = new Services();

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

        private bool _restaurantAutre;

        public bool RestaurantAutre
        {
            get { return _restaurantAutre; }
            set { _restaurantAutre = value; }
        }

        private bool _fastFoodAutre;

        public bool FastFoodAutre
        {
            get { return _fastFoodAutre; }
            set { _fastFoodAutre = value; }
        }

        private bool _peuImporteAutre;

        public bool PeuImporteAutre
        {
            get { return _peuImporteAutre; }
            set { _peuImporteAutre = value; }
        }

        #endregion

        #region Combobox

        public ObservableCollection<string> TypeDeCuisine { get; set; }
        private ObservableCollection<string> _typeDeCuisine = new ObservableCollection<string>();
        public ObservableCollection<int> MinNotation { get; set; }
        private ObservableCollection<int> _minNotation = new ObservableCollection<int>();
        public ObservableCollection<int> MaxNotation { get; set; }
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

        public bool AEmporter
        {
            get { return _aEmporter; }
            set { _aEmporter = value; }
        }

        #endregion

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RechercherBouton = new RelayCommand(Rechercher);
            
            InitComponents();
        }

        private async void InitComponents()
        {
            //List<Type_Cuisine> typeCuisinelist = await _service._typesCuisines.GetTypesCuisines();

            //foreach (Type_Cuisine tc in typeCuisinelist)
            //{
            //    _typeDeCuisine.Add(tc.Type_Cuisine1);
            //}

            for (int i = 0; i < 5; i++)
            {
                _minNotation.Add(i + 1);
                _maxNotation.Add(i + 1);
            }

            TypeDeCuisine = _typeDeCuisine;
            MinNotation = _minNotation;
            MaxNotation = _maxNotation;
        }

        private async void Rechercher()
        {
            string prix;
            string distance;
            string delai;
            string typeDeCuisine;
            string autre;
            bool aEmporter;
            int minNote;
            int maxNote;

            if (_petitBudget)
                prix = "Petit Budget";
            else if (_moyenBudget)
                prix = "Moyen Budget";
            else if (_grosBudget)
                prix = "Gros budget";
            else
                prix = "";

            distance = _distance;

            if (_courtDelai)
                delai = "Court Delai";
            else if (_moyenDelai)
                delai = "Moyen Delai";
            else if (_longDelai)
                delai = "Long Delai";
            else
                delai = "";

            typeDeCuisine = _typeCuisineChoisie;

            if (_restaurantAutre)
                autre = "Restaurant";
            else if (_fastFoodAutre)
                autre = "Fast-Food";
            else
                autre = "";

            aEmporter = _aEmporter;

            minNote = _minNotationChoisie;

            maxNote = _maxNotationChoisie;

            MessageDialog msgDialog = new MessageDialog("Prix : " + prix + " ; Distance : " + distance + " ; Délai : " + delai + " ; Type de cuisine : " + typeDeCuisine + " ; Autre : " + autre + " ; A emporter : " + aEmporter + " ; Note minimal : " + minNote + " ; Note maximale : " + maxNote, "Félicitation");
            await msgDialog.ShowAsync();
        }
    }
}
