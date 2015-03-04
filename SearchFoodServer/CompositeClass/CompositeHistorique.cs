using System;
using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeHistorique
    {
        int _idHistorique;
        int _idRestaurants;
        int _idUtilisateurs;
        DateTime _date;

        [DataMember]
        public int IdHistoriqueValue
        {
            get { return _idHistorique; }
            set { _idHistorique = value; }
        }

        [DataMember]
        public int IdRestaurantsValue
        {
            get { return _idRestaurants; }
            set { _idRestaurants = value; }
        }

        [DataMember]
        public int IdUtilisateursValue
        {
            get { return _idUtilisateurs; }
            set { _idUtilisateurs = value; }
        }

        [DataMember]
        public DateTime DateValue
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}