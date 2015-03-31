using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Navigation; 
using SearchFood.SearchFoodServiceReference;  

namespace SearchFood.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {
        private Utilisateur _utilisateur;
        private List<Historique> _historiques;
        private INavigationService _navigationService;

        public ICommand GoBackButton { get; set; }
        

        public AccountViewModel(INavigationService navigation)
        {
            _navigationService = navigation; 
            Historiques = new List<Historique>();
            GoBackButton = new RelayCommand(GoBack); 
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

        public void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
