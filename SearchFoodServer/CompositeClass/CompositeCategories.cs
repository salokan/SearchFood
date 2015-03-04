using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeCategories
    {
        int _idCategorie;
        string _nomCategorie;

        [DataMember]
        public int IdCategorieValue
        {
            get { return _idCategorie; }
            set { _idCategorie = value; }
        }

        [DataMember]
        public string NomCategorieValue
        {
            get { return _nomCategorie; }
            set { _nomCategorie = value; }
        }
    }
}