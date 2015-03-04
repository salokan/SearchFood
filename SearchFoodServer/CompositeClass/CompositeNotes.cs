using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeNotes
    {
        int _idNotes;
        int _idRestaurants;
        int _idUtilisateurs;
        double _notes;

        [DataMember]
        public int IdNotesValue
        {
            get { return _idNotes; }
            set { _idNotes = value; }
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
        public double NotesValue
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }
}