using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Navigation; 
using SearchFood.SearchFoodServiceReference;
using SearchFood.Model;
using Windows.UI.Xaml;  

namespace SearchFood.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private Utilisateur _utilisateur;
        private Historique _historique;
        private Restaurant _restaurant;
        private Categorie _categorie;
        private Type_Cuisine _typeCuisine;
        private string _nomRestaurant;
        private string _categorieRestaurant;
        private string _typeCuisineRestaurant;
        private List<Historique> _historiques;
        private Restaurant restaurant;
        private List<Restaurant> _historiqueRestaurant;
        private INavigationService _navigationService;
        private Services _service;

        public ObservableCollection<HistoriquesModel> Historiqueslist
        {
            get { return _historiqueslist; }

            set
            {
                _historiqueslist = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<HistoriquesModel> _historiqueslist = new ObservableCollection<HistoriquesModel>();

        public ICommand GoBackButton { get; set; }

        public AccountViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _service = new Services();
            Historiques = new List<Historique>();
            HistoriqueRestaurant = new List<Restaurant>();
            GoBackButton = new RelayCommand(GoBack);
            _utilisateur = ((App)(Application.Current)).UserConnected;
            InithistoriqueList();
        }

        private async void InitHistorique()
        {
            _historiques = await _service._historique.GetHistoriqueByUser(((App)(Application.Current)).UserConnected.Id_Utilisateur);

            foreach (Historique histo in _historiques)
            {
                restaurant = await _service._restaurants.GetRestaurants(histo.Id_Restaurant);
                _historiqueRestaurant.Add(restaurant);
                Restaurant = restaurant;
                Historique = histo;
                Categorie = await _service._categories.GetCategorie(restaurant.Id_Categorie);
                CategorieRestaurant = Categorie.Nom_Categorie;
                Type_Cuisine = await _service._typesCuisines.GetTypeCuisine(restaurant.Id_Type_Cuisine);
                Type_CuisineRestaurant = Type_Cuisine.Type_Cuisine1;
            }
        }

        private async void InithistoriqueList()
        {
            _historiqueslist = new ObservableCollection<HistoriquesModel>();
            _historiques = new List<Historique>();
            _historiques = await _service._historique.GetHistoriqueByUser(((App)(Application.Current)).UserConnected.Id_Utilisateur);

            foreach (Historique histo in _historiques)
            {
                restaurant = await _service._restaurants.GetRestaurants(histo.Id_Restaurant);
                _historiqueRestaurant.Add(restaurant);
                Restaurant = restaurant;
                Historique = histo;
                Categorie = await _service._categories.GetCategorie(restaurant.Id_Categorie);
                CategorieRestaurant = Categorie.Nom_Categorie;
                Type_Cuisine = await _service._typesCuisines.GetTypeCuisine(restaurant.Id_Type_Cuisine);
                Type_CuisineRestaurant = Type_Cuisine.Type_Cuisine1;


                HistoriquesModel historiqueModel = new HistoriquesModel{Date = histo.Date.ToString(), NomRestaurant = restaurant.Nom, TypeCuisine = Type_CuisineRestaurant, Categorie = CategorieRestaurant};

                _historiqueslist.Add(historiqueModel);
            }
        }

        #region Getter / Setter MVVM 
        public Utilisateur Utilisateur
        {
            get { return _utilisateur; }
            set { _utilisateur = value; RaisePropertyChanged(); }
        }
        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; RaisePropertyChanged(); }
        }

        public Historique Historique
        {
            get { return _historique; }
            set { _historique = value; RaisePropertyChanged(); }
        }

        public Categorie Categorie
        {
            get { return _categorie; }
            set { _categorie = value; RaisePropertyChanged(); }
        }

        public Type_Cuisine Type_Cuisine
        {
            get { return _typeCuisine; }
            set { _typeCuisine = value; RaisePropertyChanged(); }
        }
        public string NomRestaurant
        {
            get { return _nomRestaurant; }
            set { _nomRestaurant = value; RaisePropertyChanged(); }
        }

        public string CategorieRestaurant
        {
            get { return _categorieRestaurant; }
            set { _categorieRestaurant = value; RaisePropertyChanged(); }
        }

        public string Type_CuisineRestaurant
        {
            get { return _typeCuisineRestaurant; }
            set { _typeCuisineRestaurant = value; RaisePropertyChanged(); }
        }

        public List<Historique> Historiques
        {
            get { return _historiques; }
            set { _historiques = value; RaisePropertyChanged(); }
        }
        public List<Restaurant> HistoriqueRestaurant
        {
            get { return _historiqueRestaurant; }
            set { _historiqueRestaurant = value; RaisePropertyChanged(); }
        }

        #endregion

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
