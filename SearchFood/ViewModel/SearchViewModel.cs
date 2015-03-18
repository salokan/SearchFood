using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Navigation;

namespace SearchFood.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand RechercherBouton { get; set; }

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            RechercherBouton = new RelayCommand(Rechercher);
            
        }

        private async void Rechercher()
        {
            MessageDialog msgDialog = new MessageDialog("Vous venez d'appuyer sur le bouton rechercher", "Félicitation");
            await msgDialog.ShowAsync();
        }
    }
}
