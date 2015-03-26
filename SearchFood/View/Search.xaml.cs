using Windows.UI.Xaml;
using SearchFood.Common;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SearchFood.View
{
    public sealed partial class Search
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableDictionary DefaultViewModel
        {
            get { return defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }


        public Search()
        {
            InitializeComponent();
            navigationHelper = new NavigationHelper(this);
            navigationHelper.LoadState += navigationHelper_LoadState;
            navigationHelper.SaveState += navigationHelper_SaveState;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }


        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Inscription de NavigationHelper

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void RechercherClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            borderResultat.Visibility = Visibility.Visible;
            boutonChoisir.Visibility = Visibility.Visible;
            boutonSuivant.Visibility = Visibility.Visible;
        }
    }
}
