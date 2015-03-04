using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeTypesCuisine
    {
        int _idTypesCuisine;
        string _typesCuisine;

        [DataMember]
        public int IdTypesCuisineValue
        {
            get { return _idTypesCuisine; }
            set { _idTypesCuisine = value; }
        }

        [DataMember]
        public string TypesCuisineValue
        {
            get { return _typesCuisine; }
            set { _typesCuisine = value; }
        }
    }
}