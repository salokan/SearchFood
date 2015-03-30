﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SearchFood.Model;
using SearchFood.Navigation;
using SearchFood.SearchFoodServiceReference;
using SearchFood.View;
using SearchFood.Webservices;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace SearchFood.ViewModel
{
    public class RestauViewModel : ViewModelBase, IViewModel
    {
        private List<Commentaire> commentsListe = new List<Commentaire>();
        private INavigationService _navigationService;
        private Restaurant restaurant = new Restaurant();
        private int _idrestau;
        private string _nomRestaurant;
        private int _dureeRepas;
        private String _adresseRestaurant;
        private int _codePostal;
        private String _ville;
        private int _prixRestaurant;
        private string _siteWeb;
        private int _telephone;
        private string _mail;
        private string _latitude;
        private string _longitude;

        private Services _restauServices;
        

        #region
        public string NomRestaurant //Mot à ajouter
        {
            get
            {
                return _nomRestaurant;
            }

            set
            {
                if (_nomRestaurant != value)
                {
                    _nomRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int DureeRepas //Mot à ajouter
        {
            get
            {
                return _dureeRepas;
            }

            set
            {
                if (_dureeRepas != value)
                {
                    _dureeRepas = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string AdresseRestaurant //Mot à ajouter
        {
            get
            {
                return _adresseRestaurant;
            }

            set
            {
                if (_adresseRestaurant != value)
                {
                    _adresseRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int CodePostal //Mot à ajouter
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

        public string Ville //Mot à ajouter
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

        public int PrixRestaurant //Mot à ajouter
        {
            get
            {
                return _prixRestaurant;
            }

            set
            {
                if (_prixRestaurant != value)
                {
                    _prixRestaurant = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string SiteWeb //Mot à ajouter
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

        public int Telephone //Mot à ajouter
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

        public String Mail //Mot à ajouter
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

        public string Latitude //Mot à ajouter
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

        public string Longitude //Mot à ajouter
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

        public RestauViewModel(INavigationService navigation)
        {
            _navigationService = navigation;
            _restauServices = new Services();
            //GetRestau = new RelayCommand(Restau);
            Restau();

        }

        public ICommand GetRestau { get; set; }

        public async void Restau()
        {
            restaurant = await _restauServices._restaurants.GetRestaurants(_idrestau);
            NomRestaurant = restaurant.Nom;
            DureeRepas = (int) restaurant.Duree_repas;
            AdresseRestaurant = AdresseRestaurant = restaurant.Adresse;
            CodePostal = restaurant.Code_Postal;
            Ville = restaurant.Ville;
            PrixRestaurant = (int) restaurant.Prix;
            SiteWeb = restaurant.Site_Web;
            Telephone = restaurant.Telephone;
            Mail = restaurant.Mail;
            Latitude = restaurant.Latitude;
            Longitude = restaurant.Longitude;


            commentsListe = await _restauServices._commentaires.GetCommentaires();

            if (commentsListe.Count != 0)
            {
                
            }
            else
            {
                MessageDialog msgDialog2 = new MessageDialog("Aucun restaurant ne correspond à votre recherche", "Attention");
                await msgDialog2.ShowAsync();
            }
        }
        
        //Récupère le paramètre contenant la définition à modifier
        public void GetParameter(object parameter)
        {
            _idrestau = (int) parameter;
        }

        //Permet de réinitialiser la liste à chaque fois que l'on navigue sur cette page
        public void OnNavigatedTo()
        {

        }
    }
}
