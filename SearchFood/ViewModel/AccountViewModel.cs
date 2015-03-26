using System.Collections.Generic; 
using GalaSoft.MvvmLight; 
using SearchFood.Navigation; 
using SearchFood.SearchFoodServiceReference;  

namespace SearchFood.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private Utilisateur _utilisateur;
        private List<Historique> _historiques;
        private INavigationService _navigationService;

        public AccountViewModel(INavigationService navigation)
        {
            _navigationService = navigation; 
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
        #endregion
    }
}
