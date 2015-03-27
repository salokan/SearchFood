using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeRestaurants
    {
        int _idRestaurants;
        string _nomRestaurants;
        string _sitesWeb;
        string _mail;
        string _adresse;
        string _codePostal;
        string _ville;
        string _telephone;
        string _latitude;
        string _longitude;
        Nullable<int> _dureeRepas;
        Nullable<int> _prix;
        int _idCategories;
        int _idTypesCuisine;


        [DataMember]
        public int IdRestaurantsValue
        {
            get { return _idRestaurants; }
            set { _idRestaurants = value; }
        }

        [DataMember]
        public string NomRestaurantsValue
        {
            get { return _nomRestaurants; }
            set { _nomRestaurants = value; }
        }

        [DataMember]
        public string SitesWebValue
        {
            get { return _sitesWeb; }
            set { _sitesWeb = value; }
        }

        [DataMember]
        public string MailValue
        {
            get { return _mail; }
            set { _mail = value; }
        }

        [DataMember]
        public string AdresseValue
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        [DataMember]
        public string CodePostalValue
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }

        [DataMember]
        public string VilleValue
        {
            get { return _ville; }
            set { _ville = value; }
        }

        [DataMember]
        public string TelephoneValue
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        [DataMember]
        public string LatitudeValue
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        [DataMember]
        public string LongitudeValue
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        [DataMember]
        public Nullable<int> DureeRepasValue
        {
            get { return _dureeRepas; }
            set { _dureeRepas = value; }
        }

        [DataMember]
        public Nullable<int> PrixValue
        {
            get { return _prix; }
            set { _prix = value; }
        }

        [DataMember]
        public int IdCategoriesValue
        { 
            get { return _idCategories; }
            set { _idCategories = value; }
        }

        [DataMember]
        public int IdTypesCuisineValue
        {
            get { return _idTypesCuisine; }
            set { _idTypesCuisine = value; }
        }
    }
}