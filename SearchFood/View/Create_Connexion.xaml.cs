﻿using SearchFood.Common; 
using Windows.UI.Xaml.Controls; 
using Windows.UI.Xaml.Navigation;
 
namespace SearchFood.View
{ 
    public sealed partial class Create_Connexion : Page
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

        public Create_Connexion()
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
    }
}
